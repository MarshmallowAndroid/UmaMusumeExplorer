
#region ### copyright, version and changelog information ###
/////////////////////////////////////////////////////////////////////////////// 
// 
// Copyright (c) 2018 Nikola Bozovic. All rights reserved. 
// 
// This code is licensed under the MIT License (MIT). 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
// THE SOFTWARE. 
// 
///////////////////////////////////////////////////////////////////////////////
//
// open.imaging.DXT5
//
// version  : v0.80.18.1113
// author   : Nikola Bozovic <nigerija@gmail.com>
// desc     : LUT optimized software DXT5 (BC3) texture block decompression.
// note     : S3TC patent expired on October 2, 2017.
//            And continuation patent expired on March 16, 2018.
//            S3TC support has landed in Mesa since then.
//
// changelog:
// * 2018.09.20: initial version.
//
// * v0.80.18.1113: optimized DXT5 (BC3) to use LUTs.
//
//    1920x1080 texture decode time on 3GHz CPU:
//      debug   : ~18.1 ms
//        speed in :  ~114.6 mega bytes per sec
//        speed out:  ~458.3 mega bytes per sec
//        speed pix:  ~114.6 mega pixels per sec
//      release : ~16.6 ms
//        speed in :  ~124.9 mega bytes per sec
//        speed out:  ~499.7 mega bytes per sec
//        speed pix:  ~124.9 mega pixels per sec
//
//    Three days ago I had processing times 150~200ms. Now this is scarry 
//    fast even for C# code, have ~91% boost. This code even beats some 
//    c/c++ implementations, and by some. I don't think there is anything
//    else that could be done here to squeeze more time out of this.
//    AVX.Net is still in experimental stage....
//
// PS: if you are extracting and writting images on HDD, you will need 
//     fast SSD, preferably M2 disk to exploit this speed.
//
///////////////////////////////////////////////////////////////////////////////
#endregion

using System;

namespace open.imaging.S3TC
{

  /// <summary>
  /// <para>Software LUT's optimized DXT5 (BC3) texture block decompression.</para>
  /// <para>This is optimized version using LUT's to decode actuall block data.</para>
  /// <para></para>
  /// <para>Memory usage:</para>
  /// <para>Total bytes in COLOR(A,R,G,B) static LUT's : 2 195 456.</para>
  /// </summary>
  unsafe public static class DXT5
  {
    // memory wise concerns:
    // total bytes in C2(R,G,B) static LUT's    :   98304
    // total bytes in ALPHA static LUT          : 2097152
    // ---------------------------------------------------
    // total bytes in static luts               : 2195456

    #region ### comments/docs ###
    //
    // for mathematical formulas go to wiki: 
    // https://en.wikipedia.org/wiki/S3_Texture_Compression    
    // https://www.khronos.org/registry/DataFormat/specs/1.1/dataformat.1.1.html#S3TC
    // Note: this page has bug for BC2, BC3 how to encode colors
    // https://www.khronos.org/opengl/wiki/S3_Texture_Compression
    //
    #endregion

    #region ### internal data ###

    /// <summary>
    /// <para>DXT5 (BC3) defines shifting in precalculated alpha.</para>
    /// </summary> 
    const int __DXT5_LUT_COLOR_SHIFT_A = 24;
    /// <summary>
    /// <para>DXT5 (BC3) defines shifting in precalculated [R] component.</para>
    /// </summary>
    const int __DXT5_LUT_COLOR_SHIFT_R = 16;
    /// <summary>
    /// <para>DXT5 (BC3) defines shifting in precalculated [G] component.</para>
    /// </summary>
    const int __DXT5_LUT_COLOR_SHIFT_G = 8;
    /// <summary>
    /// <para>DXT5 (BC3) defines shifting in precalculated [B] component.</para>
    /// </summary>
    const int __DXT5_LUT_COLOR_SHIFT_B = 0;
    /// <summary>
    /// <para>DXT5 (BC3) pre calculated LUT values for alpha codes.</para>
    /// <para>index = (a0 &lt;&lt; 11) | (a1 &lt;&lt; 3) | (a);</para>
    /// </summary> 
    static uint[] __DXT5_LUT_COLOR_VALUE_A;
    /// <summary>
    /// <para>DXT5 (BC3) precalculated LUT values for [R] component for all 4 codes.</para>
    /// <para>index = ((cc0 &lt;&lt; 5) | cc1) &lt;&lt; 2;</para>
    /// </summary>
    static uint[] __DXT5_LUT_COLOR_VALUE_R;
    /// <summary>
    /// <para>DXT5 (BC3) precalculated LUT values for [G] component for all 4 codes.</para>
    /// <para>index = ((cc0 &lt;&lt; 6) | cc1) &lt;&lt; 2;</para>
    /// </summary>
    static uint[] __DXT5_LUT_COLOR_VALUE_G;
    /// <summary>
    /// <para>DXT5 (BC3) precalculated LUT values for [B] component for all 4 codes.</para>
    /// <para>index = ((cc0 &lt;&lt; 5) | cc1) &lt;&lt; 2;</para>
    /// </summary>
    static uint[] __DXT5_LUT_COLOR_VALUE_B;

    #endregion

    #region ### static ctor ###

    /// <summary>
    /// initializes static data
    /// </summary>
    static DXT5()
    {
      // execution time: less than 1 ms
      __DXT5_LUT_COLOR_VALUE_RGB_Build();      
      
      // execution time: little less than 3 ms
      __DXT5_LUT_COLOR_VALUE_A_Build();
    }

    #endregion

    #region ### public methods ###

    /// <summary>
    /// <para>DXT5 (BC3)</para>
    /// Returns expected input buffers size in bytes for specified width and height.
    /// </summary>
    /// <param name="width">Image width.</param>
    /// <param name="height">Image height.</param>
    public static int InputBufferSize(int width, int height)
    {
      // number of blocks by width * number of blocks by height * block size in bytes
      return ((width + 3) / 4) * ((height + 3) / 4) * 16;
    }

    /// <summary>
    /// <para>DXT5 (BC3)</para>
    /// Returns expected output buffers size in bytes for specified width and height.
    /// </summary>
    /// <param name="width">Image width.</param>
    /// <param name="height">Image height.</param>
    public static int OutputBufferSize(int width, int height)
    {
      // A,R,G,B are 8bit components, and you really need comments ;)
      return width * height * 4;
    }

    #endregion

    #region ### DXT5 (BC3) LOOK-UP TABLE'S (LUT's) ###

    #pragma warning disable 1587

    /// <summary>
    /// <para>DXT5 (BC3)</para>
    /// <para>Builds static __DXT5_LUT_COLOR_VALUE_A[] look-up table.</para>
    /// </summary>
    static void __DXT5_LUT_COLOR_VALUE_A_Build()
    {
      unchecked
      {
        __DXT5_LUT_COLOR_VALUE_A = new uint[524288]; // 8 * 256 * 256
        // where a[0..7]
        for (int a = 0; a <= 7; a++)
        {
          // where a0[0..255]
          for (int a0 = 0; a0 <= 255; a0++)
          {
            // where a1[0..255]
            for (int a1 = 0; a1 <= 255; a1++)
            {
              // if (a0 > a1) deliberatelly moved inside switch(a) so it can be switch jump optimized execution
              int index = (a0 << 3) | (a1 << 11) | (a); 
              switch (a)
              {
                case 0:
                  __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)a0 << __DXT5_LUT_COLOR_SHIFT_A);
                  break;
                case 1:
                  __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)a1 << __DXT5_LUT_COLOR_SHIFT_A);
                  break;
                case 2:
                  if (a0 > a1)
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)(((6 * a0) + (/**/a1)) / 7) << __DXT5_LUT_COLOR_SHIFT_A);
                  else
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)(((4 * a0) + (/**/a1)) / 5) << __DXT5_LUT_COLOR_SHIFT_A);
                  break;
                case 3:
                  if (a0 > a1)
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)(((5 * a0) + (2 * a1)) / 7) << __DXT5_LUT_COLOR_SHIFT_A);
                  else
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)(((3 * a0) + (2 * a1)) / 5) << __DXT5_LUT_COLOR_SHIFT_A);
                  break;
                case 4:
                  if (a0 > a1)
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)(((4 * a0) + (3 * a1)) / 7) << __DXT5_LUT_COLOR_SHIFT_A);
                  else
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)(((2 * a0) + (3 * a1)) / 5) << __DXT5_LUT_COLOR_SHIFT_A);
                  break;
                case 5:
                  if (a0 > a1)
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)(((3 * a0) + (4 * a1)) / 7)) << __DXT5_LUT_COLOR_SHIFT_A;
                  else
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)(((/**/a0) + (4 * a1)) / 5)) << __DXT5_LUT_COLOR_SHIFT_A;
                  break;
                case 6:
                  if (a0 > a1)
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((byte)(((2 * a0) + (5 * a1)) / 7)) << __DXT5_LUT_COLOR_SHIFT_A;
                  else
                    __DXT5_LUT_COLOR_VALUE_A[index] = 0;  // __LUT_DXT5_ALPHA_SHIFT // no point
                  break;
                case 7:
                  if (a0 > a1)
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)(((byte)(((/**/a0) + (6 * a1)) / 7)) << __DXT5_LUT_COLOR_SHIFT_A);
                  else
                    __DXT5_LUT_COLOR_VALUE_A[index] = (uint)((255) << __DXT5_LUT_COLOR_SHIFT_A);
                  break;
              }// switch(a)              
            } // a1
          } // a0
        } // a
      } // unchecked
    }

    /// <summary>
    /// <para>DXT5 (BC3)</para>
    /// <para>Builds static __DXT5_LUT_COLOR_VALUE_{R,G,B}[] look-up table(s).</para>
    /// </summary>
    static void __DXT5_LUT_COLOR_VALUE_RGB_Build()
    {
      // DXT5 (BC3) pre calculated values for r & b codes
      byte[] __DXT5_LUT_4x8 = // 0x00 - 0x1f (0-31)
        { 
            0,   8,  16,  25,  33,  41,  49,  58, 
           66,  74,  82,  90,  99, 107, 115, 123, 
          132, 140, 148, 156, 164, 173, 181, 189, 
          197, 205, 214, 222, 230, 238, 247, 255 
        };

      // DXT5 (BC3) pre calculated values for g codes
      byte[] __DXT5_LUT_8x8 = // 0x00 - 0x3f (0-63)
        {
            0,   4,   8,  12,  16,  20,  24,  28, 
           32,  36,  40,  45,  49,  53,  57,  61, 
           65,  69,  73,  77,  81,  85,  89,  93, 
           97, 101, 105, 109, 113, 117, 121, 125, 
          130, 134, 138, 142, 146, 150, 154, 158, 
          162, 166, 170, 174, 178, 182, 186, 190, 
          194, 198, 202, 206, 210, 214, 219, 223, 
          227, 231, 235, 239, 243, 247, 251, 255 
        };

      __DXT5_LUT_COLOR_VALUE_R = new uint[4096];  // 4*32*32
      __DXT5_LUT_COLOR_VALUE_G = new uint[16384]; // 4*64*64
      __DXT5_LUT_COLOR_VALUE_B = new uint[4096];  // 4*32*32

      for (int cc0 = 0; cc0 < 32; cc0++)
      { 
        for (int cc1 = 0; cc1 < 32; cc1++)
        {
          int index = ((cc0 << 5) | cc1) << 2;
          __DXT5_LUT_COLOR_VALUE_R[index | 0] = (uint)(((uint)__DXT5_LUT_4x8[cc0]) << __DXT5_LUT_COLOR_SHIFT_R);
          __DXT5_LUT_COLOR_VALUE_B[index | 0] = (uint)(((uint)__DXT5_LUT_4x8[cc0]) << __DXT5_LUT_COLOR_SHIFT_B);
          __DXT5_LUT_COLOR_VALUE_R[index | 1] = (uint)(((uint)__DXT5_LUT_4x8[cc1]) << __DXT5_LUT_COLOR_SHIFT_R);
          __DXT5_LUT_COLOR_VALUE_B[index | 1] = (uint)(((uint)__DXT5_LUT_4x8[cc1]) << __DXT5_LUT_COLOR_SHIFT_B);
          // Each RGB image data block is encoded according to the BC1 formats, 
          // with the exception that the two code bits always use the non-transparent encodings. 
          // In other words, they are treated as though color0 > color1, 
          // regardless of the actual values of color0 and color1.
          // p2 = ((2*c0)+(c1))/3
          __DXT5_LUT_COLOR_VALUE_R[index | 2] = (uint)((uint)((byte)(((__DXT5_LUT_4x8[cc0] * 2) + (__DXT5_LUT_4x8[cc1])) / 3)) << __DXT5_LUT_COLOR_SHIFT_R);
          __DXT5_LUT_COLOR_VALUE_B[index | 2] = (uint)((uint)((byte)(((__DXT5_LUT_4x8[cc0] * 2) + (__DXT5_LUT_4x8[cc1])) / 3)) << __DXT5_LUT_COLOR_SHIFT_B);
          // p3 = ((c0)+(2*c1))/3
          __DXT5_LUT_COLOR_VALUE_R[index | 3] = (uint)((uint)((byte)(((__DXT5_LUT_4x8[cc0]) + (__DXT5_LUT_4x8[cc1] * 2)) / 3)) << __DXT5_LUT_COLOR_SHIFT_R);
          __DXT5_LUT_COLOR_VALUE_B[index | 3] = (uint)((uint)((byte)(((__DXT5_LUT_4x8[cc0]) + (__DXT5_LUT_4x8[cc1] * 2)) / 3)) << __DXT5_LUT_COLOR_SHIFT_B);
        }//cc1
      }//cc0
      for (int cc0 = 0; cc0 < 64; cc0++)
      { 
        for (int cc1 = 0; cc1 < 64; cc1++)
        {
          int index = ((cc0 << 6) | cc1) << 2;
          __DXT5_LUT_COLOR_VALUE_G[index | 0] = (uint)(((uint)__DXT5_LUT_8x8[cc0]) << __DXT5_LUT_COLOR_SHIFT_G);
          __DXT5_LUT_COLOR_VALUE_G[index | 1] = (uint)(((uint)__DXT5_LUT_8x8[cc1]) << __DXT5_LUT_COLOR_SHIFT_G);
          // Each RGB image data block is encoded according to the BC1 formats, 
          // with the exception that the two code bits always use the non-transparent encodings. 
          // In other words, they are treated as though color0 > color1, 
          // regardless of the actual values of color0 and color1.
          // p2 = ((2*c0)+(c1))/3
          __DXT5_LUT_COLOR_VALUE_G[index | 2] = (uint)((uint)((byte)(((__DXT5_LUT_8x8[cc0] * 2) + (__DXT5_LUT_8x8[cc1])) / 3)) << __DXT5_LUT_COLOR_SHIFT_G);
          // p3 = ((c0)+(2*c1))/3
          __DXT5_LUT_COLOR_VALUE_G[index | 3] = (uint)((uint)((byte)(((__DXT5_LUT_8x8[cc0]) + (__DXT5_LUT_8x8[cc1] * 2)) / 3)) << __DXT5_LUT_COLOR_SHIFT_G);
        }//cc1
      }//cc0
    }

    #pragma warning restore 1587

    #endregion

    #region ### Decode ###

    /// <summary>
    /// <para>DXT5 (BC3) -> {R,G,B,A} 8-bit components with LUTs precalculated pixel format.</para>
    /// Decompresses all <paramref name="p_input">input</paramref> BC3 blocks of a compressed image 
    /// and stores the result pixel values into <paramref name="p_output">output</paramref>.
    /// </summary>
    /// <param name="width">image width.</param>
    /// <param name="height">image height.</param>
    /// <param name="p_input">pointer to compressed DXT5 (BC3) blocks, we want to decompress.</param>
    /// <param name="p_output">pointer to the image where the decoded pixels will be stored.</param>
    public static void Decode(uint width, uint height, void* p_input, void* p_output)
    {
      unchecked
      {
        byte* source = (byte*)p_input;
        uint* target = (uint*)p_output;
        uint target_4scans = (width << 2);
        uint x_block_count = (width + 3) >> 2;
        uint y_block_count = (height + 3) >> 2;

        //############################################################
        if ((x_block_count << 2) != width || (y_block_count << 2) != height)
        {
          // for images that do not fit in 4x4 texel bounds
          goto ProcessWithCheckingTexelBounds;
        }
        //############################################################
        //ProcessWithoutCheckingTexelBounds:
        //
        // NOTICE: source and target ARE aligned as 4x4 texels
        //
        // target : advance by 4 scan lines
        for (uint y_block = 0; y_block < y_block_count; y_block++, target += target_4scans)
        {
          uint* texel_x = target;
          // texel: advance by 4 texels
          for (uint x_block = 0; x_block < x_block_count; x_block++, source += 16, texel_x += 4)
          {
            // read DXT5 (BC3) block data
            //byte ac0 = *(byte*)(source);            // 00    : a0       (8bit)
            //byte ac1 = *(byte*)(source+ 1);         // 01    : a1       (8bit)            
            ulong acfnlut = *(ulong*)(source + 2);  // 02-07 : afn LUT  (48bits) 4x4x3bits
            ushort cc0 = *(ushort*)(source + 8);    // 08-09 : cc0      (16bits)
            ushort cc1 = *(ushort*)(source + 10);   // 0a-0b : cc1      (16bits)
            uint ccfnlut = *(uint*)(source + 12);   // 0c-0f : ccfn LUT (32bits) 4x4x2bits

            // alpha code and color code [r,g,b] indexes to luts         
            uint ccr = ((uint)((cc0 & 0xf800) >> 4) | (uint)((cc1 & 0xf800) >> 9));
            uint ccg = ((uint)((cc0 & 0x07E0) << 3) | (uint)((cc1 & 0x07E0) >> 3));
            uint ccb = ((uint)((cc0 & 0x001F) << 7) | (uint)((cc1 & 0x001F) << 2));
            //uint ac = ((uint)ac0 << 3) | ((uint)ac1 << 11);
            uint ac = (uint)((*(ushort*)source) << 3);

            // process 4x4 texels
            uint* texel = texel_x;
            for (uint by = 0; by < 4; by++, texel += width)
            {
              for (uint bx = 0; bx < 4; bx++, acfnlut >>= 3, ccfnlut >>= 2)
              {              
                uint acfn = (uint)(acfnlut & 0x07);                
                uint ccfn = (uint)(ccfnlut & 0x03);
                
                *(texel + bx) = (uint)
                  (
                    __DXT5_LUT_COLOR_VALUE_A[ac | acfn] |
                    __DXT5_LUT_COLOR_VALUE_R[ccr | ccfn] |
                    __DXT5_LUT_COLOR_VALUE_G[ccg | ccfn] |
                    __DXT5_LUT_COLOR_VALUE_B[ccb | ccfn]
                  );
              }//bx
            }//by
          }//x_block
        }//y_block
        return;
        //
        //############################################################
        // NOTICE: source and target ARE NOT aligned to 4x4 texels, 
        //         We must check for End Of Image (EOI) in this case.
        //############################################################
        // lazy to write boundary separate processings.
        // Just end of image (EOI) pointer check only.
        // considering that I have encountered few images that are not
        // aligned to 4x4 texels, this should be almost never called.
        // takes ~500us (0.5ms) more time processing 2MB pixel images.
        //############################################################
        //
      ProcessWithCheckingTexelBounds:
        uint* EOI = target + (width * height); // ok, one multiply op ;)
        // target : advance by 4 scan lines
        for (uint y_block = 0; y_block < y_block_count; y_block++, target += target_4scans)
        {
          uint* texel_x = target;
          // texel: advance by 4 texels
          for (uint x_block = 0; x_block < x_block_count; x_block++, source += 16, texel_x += 4)
          {
            // read DXT5 (BC3) block data
            //byte ac0 = *(byte*)(source);            // 00    : a0       (8bit)
            //byte ac1 = *(byte*)(source+ 1);         // 01    : a1       (8bit)
            ulong acfnlut = *(ulong*)(source + 2);  // 02-07 : afn LUT  (48bits) 4x4x3bits
            ushort cc0 = *(ushort*)(source + 8);    // 08-09 : cc0      (16bits)
            ushort cc1 = *(ushort*)(source + 10);   // 0a-0b : cc1      (16bits)
            uint ccfnlut = *(uint*)(source + 12);   // 0c-0f : ccfn LUT (32bits) 4x4x2bits

            // alpha code and color code [r,g,b] indexes to lut values           
            uint ccr = ((uint)((cc0 & 0xf800) >> 4) | (uint)((cc1 & 0xf800) >> 9));
            uint ccg = ((uint)((cc0 & 0x07E0) << 3) | (uint)((cc1 & 0x07E0) >> 3));
            uint ccb = ((uint)((cc0 & 0x001F) << 7) | (uint)((cc1 & 0x001F) << 2));
            //uint ac = ((uint)ac0 << 3) | ((uint)ac1 << 11);
            uint ac = (uint)((*(ushort*)source) << 3);

            // process 4x4 texels
            uint* texel = texel_x;
            for (uint by = 0; by < 4; by++, texel += width)
            {
              //############################################################
              // Check Y Bound (break: no more texels available for block)
              if (texel >= EOI) break;
              //############################################################
              for (uint bx = 0; bx < 4; bx++, acfnlut >>= 3, ccfnlut >>= 2)
              {              
                //############################################################
                // Check X Bound (continue: need ac|ccfnlut to complete shift)
                if (texel + bx >= EOI) continue;
                //############################################################
                uint acfn = (uint)(acfnlut & 0x07);                
                uint ccfn = (uint)(ccfnlut & 0x03);
                
                *(texel + bx) = (uint)
                  (
                    __DXT5_LUT_COLOR_VALUE_A[ac | acfn] |
                    __DXT5_LUT_COLOR_VALUE_R[ccr | ccfn] |
                    __DXT5_LUT_COLOR_VALUE_G[ccg | ccfn] |
                    __DXT5_LUT_COLOR_VALUE_B[ccb | ccfn]
                  );
              }//bx
            }//by
          }//x_block
        }//y_block
      }//unchecked
    }

    #endregion
  }
}
