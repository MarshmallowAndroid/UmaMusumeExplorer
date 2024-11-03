using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeData
{
    [Flags]
    public enum AssetBundleGroup : int
    {
        Default = 0x00,
        DeleteOnLogin = 0x01,
        DownloadLogin = 0x02,
        Tutorial = 0x04,
        HomeLogin = 0x08,
        RequiredTutorialStart = 0x10,
        DelayRelease = 0x20,
        RealFanfare = 0x40,
        WithRealFanfare = 0x80
    }
}
