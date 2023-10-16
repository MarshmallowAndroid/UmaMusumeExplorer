using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeData
{
    public enum ManifestEntryKind : byte
    {
        Default = 0,
        AssetManifest = 1,
        PlatformManifest = 2,
        RootManifest = 3,
        Master = 10,
        Sound = 11,
        Movie = 12,
        Font = 13
    }
}
