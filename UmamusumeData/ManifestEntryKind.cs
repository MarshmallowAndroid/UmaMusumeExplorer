using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmamsumeData
{
    public enum ManifestEntryKind : byte
    {
        Default = 0x0,
        AssetManifest = 0x1,
        PlatformManifest = 0x2,
        RootManifest = 0x3,
        Master = 0xA,
        Sound = 0xB,
        Movie = 0xC,
        Font = 0xD
    }
}
