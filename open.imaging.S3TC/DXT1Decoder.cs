
//#define DEBUG_LUTS_BUILD_TIME

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
// open.imaging.DXT1Decoder
//
// version  : v0.80.18.1113
// author   : Nikola Bozovic <nigerija@gmail.com>
// desc     : LUT optimized software DXT1 (BC1) texture block decompression.
// note     : S3TC patent expired on October 2, 2017. 
//            And continuation patent expired on March 16, 2018.
//            S3TC support has landed in Mesa since then.
//
// changelog:
// * 2018.09.25: initial version.
//   Slightly different version from DXT1 class that allows support of 
//   different pixel component formats. Slightly slower, but it's negligible.
//   Compiler is optimizing constants better, against static variables.
//
//   For more details on performance check DXT1 class (DXT1.cs).
//
///////////////////////////////////////////////////////////////////////////////
#endregion

using System;

namespace open.imaging.S3TC
{

  /// <summary>
  /// Defines DXT1Decoders output pixel format.
  /// </summary>
  public enum DXT1PixelFormat
  {
    /// <summary>4 byte texel:|B|G|R|A| (also default if incorrect pixel format specified.)</summary>
    BGRA = 0,
    /// <summary>4 byte texel:|R|G|B|A|</summary>
    RGBA = 1,
    /// <summary>4 byte texel:|A|R|G|B|</summary>
    ARGB = 2,
    /// <summary>4 byte texel:|A|B|G|R|</summary>
    ABGR = 3,
  }

  /// <summary>
  /// <para>Software LUT's optimized DXT1 (BC1) texture block decompression.</para>
  /// <para>This is optimized version using LUT's to decode actuall block data, 
  /// with custom output pixel component format.</para>
  /// <para>See also: <seealso cref="SetPixelFormat"/>().</para>
  /// <para>Memory usage:</para>
  /// <para>Total bytes in COLOR(A,R,G,B) static LUT's : 196 608 bytes.</para>
  /// </summary>
  /// <remarks>
  /// <para>NOTICE: LUT's aren't thread safe, meaning if you need different output 
  /// pixel formats you may end with corruped output images.</para>
  /// </remarks>
  unsafe public static class DXT1Decoder
  {
#if DEBUG_LUTS_BUILD_TIME
    static HighPerformanceCounterEx hpc = new HighPerformanceCounterEx();
    static int meter0 = hpc.Reset("DXT1Decoder::LUTBuild");
    public static string GetStats()
    {
      return hpc.ShowStatistics();
    }
#endif

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
    /// default pixel format.
    /// </summary>
    static DXT1PixelFormat __OutputPixelFormat = DXT1PixelFormat.BGRA;
    /// <summary>
    /// DXT1 (BC1) defines shifting in precalculated alpha
    /// </summary>
    static int __DXT1_LUT_COLOR_SHIFT_A = 24;
    /// <summary>
    /// DXT1 (BC1) defines shifting in precalculated [R] component
    /// </summary>
    static int __DXT1_LUT_COLOR_SHIFT_R = 16;
    /// <summary>
    /// DXT1 (BC1) defines shifting in precalculated [G] component
    /// </summary>
    static int __DXT1_LUT_COLOR_SHIFT_G = 8;
    /// <summary>
    /// DXT1 (BC1) defines shifting in precalculated [B] component
    /// </summary>
    static int __DXT1_LUT_COLOR_SHIFT_B = 0;
    /// <summary>
    /// <para>DXT1 (BC1) precalculated LUT values for [R] component for all 4 codes.</para>
    /// <para>index = ((cc0 &lt;&lt; 6) | (cc1 &lt;&lt; 1) | (ac)) &lt;&lt; 2; // 2 bits for ccfn</para>
    /// </summary>
    static uint[] __DXT1_LUT_COLOR_VALUE_R;
    /// <summary>
    /// <para>DXT1 (BC1) precalculated LUT values for [G] component for all 4 codes.</para>
    /// <para>int index = ((cc0 &lt;&lt; 7) | (cc1 &lt;&lt; 1) | (ac)) &lt;&lt; 2; // 2 bits for ccfn</para>
    /// </summary>
    static uint[] __DXT1_LUT_COLOR_VALUE_G;
    /// <summary>
    /// <para>DXT1 (BC1) precalculated LUT values for [B] component for all 4 codes.</para>
    /// <para>index = ((cc0 &lt;&lt; 6) | (cc1 &lt;&lt; 1) | (ac)) &lt;&lt; 2; // 2 bits for ccfn</para>
    /// </summary>
    static uint[] __DXT1_LUT_COLOR_VALUE_B;

    #endregion

    #region ### static ctor ###

    /// <summary>
    /// initializes static data.
    /// </summary>
    static DXT1Decoder()
    {      
      SetPixelFormat(__OutputPixelFormat);
    }

    #endregion

    #region ### public methods ###

    /// <summary>
    /// <para>DXT1 (BC1)</para>
    /// Returns expected input buffers size in bytes for specified width and height.
    /// </summary>
    /// <param name="width">Image width.</param>
    /// <param name="height">Image height.</param>
    public static int InputBufferSize(int width, int height)
    {
      // number of blocks by width * number of blocks by height * block size in bytes
      return ((width + 3) / 4) * ((height + 3) / 4) * 8;
    }

    /// <summary>
    /// <para>DXT1 (BC1)</para>
    /// Returns expected output buffers size in bytes for specified width and height of image.
    /// </summary>
    /// <param name="width">Image width.</param>
    /// <param name="height">Image height.</param>
    public static int OutputBufferSize(int width, int height)
    {      
      return width * height * 4;
    }  

    /// <summary>
    /// <para>DXT1 (BC1)</para>
    /// <para>Allows override of default output pixel format, which dictates how LUT's are built.</para>
    /// <remarks>NOTICE: LUT's will be rebuilt only if pixelFomat is not same as current.</remarks>
    /// </summary>
    /// <param name="pixelFormat">Defines decoding output pixel format.</param>
    public static void SetPixelFormat(DXT1PixelFormat pixelFormat)
    {
      bool rebuildLut = (__OutputPixelFormat != pixelFormat);
      __OutputPixelFormat = pixelFormat;
      switch (__OutputPixelFormat)
      {
        case DXT1PixelFormat.ABGR:
          __DXT1_LUT_COLOR_SHIFT_A = 0;
          __DXT1_LUT_COLOR_SHIFT_B = 8;
          __DXT1_LUT_COLOR_SHIFT_G = 16;
          __DXT1_LUT_COLOR_SHIFT_R = 24;
          break;
        case DXT1PixelFormat.ARGB:
          __DXT1_LUT_COLOR_SHIFT_A = 0;
          __DXT1_LUT_COLOR_SHIFT_R = 8;
          __DXT1_LUT_COLOR_SHIFT_G = 16;
          __DXT1_LUT_COLOR_SHIFT_B = 24;
          break;
        case DXT1PixelFormat.RGBA:
          __DXT1_LUT_COLOR_SHIFT_R = 0;
          __DXT1_LUT_COLOR_SHIFT_G = 8;
          __DXT1_LUT_COLOR_SHIFT_B = 16;
          __DXT1_LUT_COLOR_SHIFT_A = 24;
          break;
        case DXT1PixelFormat.BGRA:
        default:
          __DXT1_LUT_COLOR_SHIFT_B = 0;
          __DXT1_LUT_COLOR_SHIFT_G = 8;
          __DXT1_LUT_COLOR_SHIFT_R = 16;
          __DXT1_LUT_COLOR_SHIFT_A = 24;
          break;
      }
      if (rebuildLut || null == __DXT1_LUT_COLOR_VALUE_R)
      {
        __DXT1_LUT_COLOR_VALUE_RGB_Build();
      }
    }

    #endregion

    #region ### DXT1 (BC1) LOOK-UP TABLE'S (LUT's) ###

    /// <summary>
    /// <para>DXT1 (BC1)</para>
    /// <para>Builds static __DXT5_LUT_COLOR_VALUE_{A,R,G,B}[] look-up table(s).</para>
    /// </summary>
    static void __DXT1_LUT_COLOR_VALUE_RGB_Build()
    {
#if DEBUG_LUTS_BUILD_TIME
      hpc.Reset(meter0);
#endif
      //[   0] '__DXT1_LUT_COLOR_VALUE_RGB_Build' |   0.381416 | 1000 |   0.000381 |

      // DXT1 (BC1) pre calculated values for r & b codes
      byte[] __DXT1_LUT_4x8 = // 0x00 - 0x1f (0-31)
        { 
            0,   8,  16,  25,  33,  41,  49,  58, 
           66,  74,  82,  90,  99, 107, 115, 123, 
          132, 140, 148, 156, 164, 173, 181, 189, 
          197, 205, 214, 222, 230, 238, 247, 255 
        };

      // DXT1 (BC1) pre calculated values for g codes
      byte[] __DXT1_LUT_8x8 = // 0x00 - 0x3f (0-63)
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

      // DXT1 (BC1) pre calculated values for alpha codes
      uint __DXT1_LUT_COLOR_VALUE_A = unchecked((uint)(0xff << __DXT1_LUT_COLOR_SHIFT_A));

      // instantiate only once
      if (null == __DXT1_LUT_COLOR_VALUE_R)
      {
        __DXT1_LUT_COLOR_VALUE_R = new uint[8192];  // 4*2*32*32 (4:code)*(2:alpha)*(32:c0(r)matrix4x8)*(32:c1(r)matrix4x8)
        __DXT1_LUT_COLOR_VALUE_G = new uint[32768]; // 4*2*64*64 (4:code)*(2:alpha)*(64:c0(g)matrix8x8)*(64:c1(g)matrix8x8)
        __DXT1_LUT_COLOR_VALUE_B = new uint[8192];  // 4*2*32*32 (4:code)*(2:alpha)*(32:c0(b)matrix4x8)*(32:c1(b)matrix4x8)
      }

      #region ### build LUT for r,b components ###
      // alpha code 1bit
      for (int ac = 0; ac <= 1; ac++)
      {
        // color code 0 per [component]
        for (int cc0 = 0; cc0 < 32; cc0++)
        {
          // color code 1 per [component]
          for (int cc1 = 0; cc1 < 32; cc1++)
          {
            // 4*2*32*32 (4:code)*(2:alpha)*(32:c0(r,b)matrix4x8)*(32:c1(r,b)matrix4x8)
            int index = ((cc0 << 6) | (cc1 << 1) | (ac)) << 2; // 2 bits for ccfn [0..3]
            __DXT1_LUT_COLOR_VALUE_R[index | 0] = __DXT1_LUT_COLOR_VALUE_A | (uint)(((uint)__DXT1_LUT_4x8[cc0]) << __DXT1_LUT_COLOR_SHIFT_R);
            __DXT1_LUT_COLOR_VALUE_B[index | 0] = __DXT1_LUT_COLOR_VALUE_A | (uint)(((uint)__DXT1_LUT_4x8[cc0]) << __DXT1_LUT_COLOR_SHIFT_B);
            __DXT1_LUT_COLOR_VALUE_R[index | 1] = __DXT1_LUT_COLOR_VALUE_A | (uint)(((uint)__DXT1_LUT_4x8[cc1]) << __DXT1_LUT_COLOR_SHIFT_R);
            __DXT1_LUT_COLOR_VALUE_B[index | 1] = __DXT1_LUT_COLOR_VALUE_A | (uint)(((uint)__DXT1_LUT_4x8[cc1]) << __DXT1_LUT_COLOR_SHIFT_B);
            if (cc0 > cc1)
            {
              // p2 = ((2*c0)+(c1))/3
              __DXT1_LUT_COLOR_VALUE_R[index | 2] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_4x8[cc0] * 2) + (__DXT1_LUT_4x8[cc1])) / 3)) << __DXT1_LUT_COLOR_SHIFT_R);
              __DXT1_LUT_COLOR_VALUE_B[index | 2] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_4x8[cc0] * 2) + (__DXT1_LUT_4x8[cc1])) / 3)) << __DXT1_LUT_COLOR_SHIFT_B);
              // p3 = ((c0)+(2*c1))/3              
              __DXT1_LUT_COLOR_VALUE_R[index | 3] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_4x8[cc0]) + (__DXT1_LUT_4x8[cc1] * 2)) / 3)) << __DXT1_LUT_COLOR_SHIFT_R);
              __DXT1_LUT_COLOR_VALUE_B[index | 3] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_4x8[cc0]) + (__DXT1_LUT_4x8[cc1] * 2)) / 3)) << __DXT1_LUT_COLOR_SHIFT_B);
            }
            else // (c0 <= c1)
            {
              // p2 = (c0/2)+(c1/2)
              __DXT1_LUT_COLOR_VALUE_R[index | 2] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_4x8[cc0] / 2) + (__DXT1_LUT_4x8[cc1] / 2)))) << __DXT1_LUT_COLOR_SHIFT_R);
              __DXT1_LUT_COLOR_VALUE_B[index | 2] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_4x8[cc0] / 2) + (__DXT1_LUT_4x8[cc1] / 2)))) << __DXT1_LUT_COLOR_SHIFT_B);
              if (ac == 0)
              {
                // p3 = (color0 + 2*color1) / 3
                __DXT1_LUT_COLOR_VALUE_R[index | 3] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_4x8[cc0]) + (__DXT1_LUT_4x8[cc1] * 2)) / 3)) << __DXT1_LUT_COLOR_SHIFT_R);
                __DXT1_LUT_COLOR_VALUE_B[index | 3] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_4x8[cc0]) + (__DXT1_LUT_4x8[cc1] * 2)) / 3)) << __DXT1_LUT_COLOR_SHIFT_B);
              }
              else // tr == 1
              {
                // p3 == 0
                __DXT1_LUT_COLOR_VALUE_R[index | 3] = 0; // transparent black
                __DXT1_LUT_COLOR_VALUE_B[index | 3] = 0; // transparent black
              }
            }//(c0 <= c1)
          }//cc1
        }//cc0
      }//ac
      #endregion
      #region ### build LUT for g component ###
      // alpha code 1bit
      for (int ac = 0; ac <= 1; ac++)
      {
        // color code 0 per [component]
        for (int cc0 = 0; cc0 < 64; cc0++)
        {
          // color code 1 per [component]
          for (int cc1 = 0; cc1 < 64; cc1++)
          {
            // 4*2*64*64 (4:code)*(2:alpha)*(64:c0(g)matrix8x8)*(64:c1(g)matrix8x8)
            int index = ((cc0 << 7) | (cc1 << 1) | (ac)) << 2; // 2 bits for ccfn
            __DXT1_LUT_COLOR_VALUE_G[index | 0] = __DXT1_LUT_COLOR_VALUE_A | (uint)(((uint)__DXT1_LUT_8x8[cc0]) << __DXT1_LUT_COLOR_SHIFT_G);
            __DXT1_LUT_COLOR_VALUE_G[index | 1] = __DXT1_LUT_COLOR_VALUE_A | (uint)(((uint)__DXT1_LUT_8x8[cc1]) << __DXT1_LUT_COLOR_SHIFT_G);
            if (cc0 > cc1)
            {
              // p2 = ((2*c0)+(c1))/3
              __DXT1_LUT_COLOR_VALUE_G[index | 2] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_8x8[cc0] * 2) + (__DXT1_LUT_8x8[cc1])) / 3)) << __DXT1_LUT_COLOR_SHIFT_G);
              // p3 = ((c0)+(2*c1))/3
              __DXT1_LUT_COLOR_VALUE_G[index | 3] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_8x8[cc0]) + (__DXT1_LUT_8x8[cc1] * 2)) / 3)) << __DXT1_LUT_COLOR_SHIFT_G);
            }
            else // (c0 <= c1)
            {
              // p2 = (c0/2)+(c1/2)
              __DXT1_LUT_COLOR_VALUE_G[index | 2] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_8x8[cc0] / 2) + (__DXT1_LUT_8x8[cc1]) / 2))) << __DXT1_LUT_COLOR_SHIFT_G);
              if (ac == 0)
              {
                // p3 = (color0 + 2*color1) / 3
                __DXT1_LUT_COLOR_VALUE_G[index | 3] = __DXT1_LUT_COLOR_VALUE_A | (uint)((uint)((byte)(((__DXT1_LUT_8x8[cc0] / 2) + (__DXT1_LUT_8x8[cc1]) / 2))) << __DXT1_LUT_COLOR_SHIFT_G);
              }
              else
              {
                // p3 == 0
                __DXT1_LUT_COLOR_VALUE_G[index | 3] = 0; // transparent black
              }
            }//(c0 <= c1)
          }//cc1
        }//cc0
      }//ac
      #endregion
#if DEBUG_LUTS_BUILD_TIME
      hpc.Sum(meter0);
#endif
    }
   
    #endregion

    #region ### Decode ###

    /// <summary>
    /// <para>DXT1 (BC1) -> {A,R,G,B} 8-bit components with LUTs precalculated pixel format.</para>
    /// Decompresses all <paramref name="p_input">input</paramref> BC1 blocks of a compressed image 
    /// and stores the result pixel values into <paramref name="p_output">output</paramref>.
    /// </summary>
    /// <param name="width">image width.</param>
    /// <param name="height">image height.</param>
    /// <param name="p_input">pointer to compressed DXT1 (BC1) blocks, we want to decompress.</param>
    /// <param name="p_output">pointer to the image where the decoded pixels will be stored.</param>
    public static void Decode(uint width, uint height, void* p_input, void* p_output)
    {
      unchecked
      {
        byte* source = (byte*)p_input; // block size: 64bit
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
          for (uint x_block = 0; x_block < x_block_count; x_block++, source += 8, texel_x += 4)
          {
            // read DXT1 (BC1) block data
            ushort cc0 = *(ushort*)(source);      // 00-01 : cc0       (16bits)
            ushort cc1 = *(ushort*)(source + 2);  // 02-03 : cc1       (16bits)
            uint ccfnlut = *(uint*)(source + 4);  // 04-07 : ccfn LUT  (32bits) 4x4x2bits
            uint ac = (uint)(cc0 > cc1 ? 0 : 4);  // coded (cc0<=cc1) 1bit transparency

            // color code [r,g,b] indexes to lut values
            uint ccr = ((uint)((cc0 & 0xf800) >> 3) | (uint)((cc1 & 0xf800) >> 8)) | ac;
            uint ccg = ((uint)((cc0 & 0x07E0) << 4) | (uint)((cc1 & 0x07E0) >> 2)) | ac;
            uint ccb = ((uint)((cc0 & 0x001F) << 8) | (uint)((cc1 & 0x001F) << 3)) | ac;

            // process 4x4 texels
            uint* texel = texel_x;
            for (uint by = 0; by < 4; by++, texel += width) // next line
            {
              for (int bx = 0; bx < 4; bx++, ccfnlut >>= 2)
              {
                uint ccfn = (ccfnlut & 0x03);
                *(texel + bx) = (uint)
                  (
                    __DXT1_LUT_COLOR_VALUE_R[ccr | ccfn] |
                    __DXT1_LUT_COLOR_VALUE_G[ccg | ccfn] |
                    __DXT1_LUT_COLOR_VALUE_B[ccb | ccfn]
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
        uint* EOI = target + (width * height);
        // target : advance by 4 scan lines
        for (uint y_block = 0; y_block < y_block_count; y_block++, target += target_4scans)
        {
          uint* texel_x = target;
          // texel: advance by 4 texels
          for (uint x_block = 0; x_block < x_block_count; x_block++, source += 8, texel_x += 4)
          {
            // read DXT1 (BC1) block data
            ushort cc0 = *(ushort*)(source);      // 00-01 : cc0       (16bits)
            ushort cc1 = *(ushort*)(source + 2);  // 02-03 : cc1       (16bits)
            uint ccfnlut = *(uint*)(source + 4);  // 04-07 : ccfn LUT  (32bits) 4x4x2bits
            uint ac = (uint)(cc0 > cc1 ? 0 : 4);

            // color code [r,g,b] indexes to luts
            uint ccr = ((uint)((cc0 & 0xf800) >> 3) | (uint)((cc1 & 0xf800) >> 8)) | ac;
            uint ccg = ((uint)((cc0 & 0x07E0) << 4) | (uint)((cc1 & 0x07E0) >> 2)) | ac;
            uint ccb = ((uint)((cc0 & 0x001F) << 8) | (uint)((cc1 & 0x001F) << 3)) | ac;

            // process 4x4 texels
            uint* texel = texel_x;
            for (uint by = 0; by < 4; by++, texel += width) // next line
            {
              //############################################################
              // Check Y Bound (break: no more texels available for block)
              if (texel >= EOI) break;
              //############################################################
              for (int bx = 0; bx < 4; bx++, ccfnlut >>= 2)
              {
                //############################################################
                // Check X Bound (continue: need ccfnlut to complete shift)
                if (texel + bx >= EOI) continue;
                //############################################################
                uint ccfn = (ccfnlut & 0x03);
                *(texel + bx) = (uint)
                  (
                    __DXT1_LUT_COLOR_VALUE_R[ccr | ccfn] |
                    __DXT1_LUT_COLOR_VALUE_G[ccg | ccfn] |
                    __DXT1_LUT_COLOR_VALUE_B[ccb | ccfn]
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
