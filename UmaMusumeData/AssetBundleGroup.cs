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
        Default = 0,
        DeleteOnLogin = 1,
        DownloadLogin = 2,
        Tutorial = 4,
        HomeLogin = 8,
        RequiredTutorialStart = 16,
        DelayRelease = 32,
        RealFanfare = 64,
        WithRealFanfare = 128
    }
}
