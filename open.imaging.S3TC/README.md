# open.imaging.S3TC
LUT optimized software DXT1 (BC1), DXT3 (BC2), DXT5 (BC3) texture block decompression.

readme.txt from c++ accompaning project


# DYNAMIC LINK LIBRARY : openS3TC Project Overview


Introduction:
-------------
  
Decompress S3TC DXT1 (BC1) and DXT5 (BC3) texture block compressed images.

Main purpose of this library was to compare C# LUT optimized decompressing 
functions, against few open source projects decoding same S3TC formats. 
Also against the same original code from C# rewritten in c/c++ for comparison
against same code only the difference in language/compiler we use.

For comparison against other algorithms I've took only few projects.
Others seams very similar to Benjamin Dobell's version, and MS was also 
similar but they are using AVX XM code. 

Original C# code alongside with this library is also provided.
C# project name is open.imaging.S3TC, will try to provide other S3TC 
algorithms along with DXT1 (BC1) and DXT5 (BC3), and in time will try also
to provide LUT optimized or with other means optimized encoding of same.

Needed real time decompression for some other project, and went OCB road on 
optimizations, wanted to see how far I can push C#.

All code was on fly using math to decode pixels (taxels). Where I have 
decided to remove math from equation during decoding process, and tried
fit nicely code to hit some if-branch predictions when possible.
  
DXT1 and DXT5 decompression algorithms by Benjamin Dobell are available here
https://github.com/Benjamin-Dobell/s3tc-dxt-decompression
  
Tested also an FasTC statically linked but no longer, here is why:
  DXT1 decompression works, but decode time in release > 72ms.
  DXT5 decompression FAILS BADLY, decode time in release > 65ms.
  DXT5 decompression didn't pass test phase at all, since some images were 
  garbled on output.
So FasTC lib removed since doesn't satisfy first criteria to decode 
correctly all DXT5 (BC5) images.
One C# variant I originally wrote under 2 hours was also removed (100~200ms).

Compilers:
----------

* Microsoft Visual C++ 2010  (10.0.40219.1 SP1Rel) platform toolset v100
    c++ release compiler : /MP /O2 /Oi /Ot /GS- /GY- /arch:SSE2
    c++ release linker   : /OPT:REF /OPT:ICF
      - not that code itself uses any of : /MP /arch:SSE2

* Microsoft Visual C++ 2017 (Version 15.8.4) platform toolset v141
    VisualStudio.15.Release/15.8.4+28010.2026
    c++ release compiler : /MP /O2 /Oi /Ot /GS- /GY- /arch:SSE2
    c++ release linker   : /OPT:REF /OPT:ICF
      - not that code itself uses any of : /MP /arch:SSE2

* Microsoft Visual C# 2010   (10.0.40219.1 SP1Rel) (.Net:4.7.03062.0 SP1Rel)
* Microsoft Visual C# 2017   (VisualStudio.15.Release/15.8.4+28010.2026) 
                             (.Net:4.7.03062) 
    C# Tools   2.9.0-beta8-63208-01

Timings are strange considering VS2010|vs2017 VC++ platform toolset in use.
I've got better timings in release version when using v100 between 0.2~0.5 ms
against v141. It's like v100 platform toolset is generating better optimized
code? Tested both Visual Studio 2010 and Visual Studio 2017 with v100, and 
both give same results. Code compiled with platform toolset v100 gives 
better performance. Would like someone to explain this to me why compiler 
written eight years ago gives better performance, and better by 11% in some
cases which is not that small. 

Test conditions: 
----------------

  * Test CPU  : Intel 3GHz (2 cores)
  * Source    : 1920x1080 DXT1/DXT3/DXT5 (1000 different images)
  * Target    : 1920x1080 BGRA (easily can be changed to other formats)
  * No# Tests : for each algorithm > 2 000 tests on all images. Total > 2 000 000 tests.
  
Test results:
-------------

  - All times are in milliseconds, and are approximations for referenced CPU
  -
  - module/file       | debug | release | function
  -
  - openS3TC_DXT1.cpp |  11.1 |     5.3 | DXT1Decompress() vs2010|vs2017 v100
  - openS3TC_DXT3.cpp |  16.2 |     7.3 | DXT3Decompress() vs2010|vs2017 v100
  - openS3TC_DXT5.cpp |  16.4 |     7.7 | DXT5Decompress() vs2010|vs2017 v100
  - openS3TC_DXT1.cpp |  11.1 |     5.8 | DXT1Decompress() vs2017 v141
  - openS3TC_DXT3.cpp |  16.2 |     8.0 | DXT3Decompress() vs2017 v141
  - openS3TC_DXT5.cpp |  16.4 |     7.9 | DXT5Decompress() vs2017 v141
  - CS::DXT1.cs       |  14.2 |    12.2 | C# DXT1.Decompress() 
  - CS::DXT3.cs       |  18.1 |    16.2 | C# DXT3.Decompress() 
  - CS::DXT5.cs       |  18.1 |    16.6 | C# DXT5.Decompress() 
  - s3tc_bd.cpp       | 100.0 |    28.0 | BlockDecompressImageDXT1()
  - s3tc_bd.cpp       |  95.0 |    20.0 | BlockDecompressImageDXT5()
  -
  for more detailed statistics check module/file comments.

  NOTICE: Benjamin Dobell's s3tc_bd.cpp removed from project due cleanup,
          and not to have any copyright issues with this code.
          You can still find his code online on github link provided
		  in text above.

Conclusion:
-----------

C++ obviously runs faster, but not much from same c# implementation.
This implementation has constant speed across different images of same size.
Benjamin Dobell's code, unfortunately not optimized, and is slower.
Also Dobell's code is not constant in speed, due math on code functions.
But never the less I've averaged it across different images for time data.
And didn’t spent much time on testing in vs2010|vs2017 or v100|v141...
Also please notice Benjamins code may fail on non 4x4 taxel aligned images,
(height check is missing) but I currently didn't had any such images to test.

In conclusion C# code speed is now acceptable for production code.
Since we can decompress/convert an over 50 2MP images per one second.
Also C++ version now kills, and it's all done without AVX code.
Benjamins code is also acceptable speed but, it can be optimized to 
squezze more out of it, even with inlined math or AVX code.
But I will leave that optimization for Dobell's team or someone else ;)

Next:
-----

Some brain farting of mine...

Next level of optimizations would be of course AVX, or not? do we need it?
Thinking on checking again AVX code how it behaves, and somehow I don't
see AVX beign faster, I see it slower. But I might be wrong, but would
need more time to find fastest AVX functions for task, and do proper test.

DX tools in SDK for Win 10 have sample code Desktop 2017 with AVX code.
Downloaded quickly source code to peek into (XM's):
~\DirectXTex-master\DDSView\Bin\Desktop_2017\Win32\Debug
This implementation is converting everything into floats, so we would
need our own implementation with unsigned int(s).

Release:
--------

2018.09.25 C# project open.imaging.S3TC is complete with DXT1, and DXT5
           including custom output pixel format decoders, if someone 
           needs complete solution or way how to implement different
           pixel formats and not to affect much the decoding speed.

2018.11.09 finally some free time, replace old MakeVersion v1 with v2
           cleaned up code a bit, removed test compare code from project.
           
