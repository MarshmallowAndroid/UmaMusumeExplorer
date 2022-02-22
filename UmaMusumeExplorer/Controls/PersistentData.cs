using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmaMusumeFiles;
using UmaMusumeFiles.Tables;

namespace UmaMusumeExplorer.Controls
{
    internal static class PersistentData
    {
        private static IEnumerable<GameAsset> bgmGameFiles;
        private static IEnumerable<RaceBgm> raceBgm;
        private static IEnumerable<RaceBgmPattern> raceBgmPatterns;
        private static IEnumerable<CharaData> charaDatas;

        public static IEnumerable<GameAsset> BgmGameFiles
        {
            get
            {
                if (bgmGameFiles == null)
                    bgmGameFiles = UmaFileHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("sound/b/"));

                return bgmGameFiles;
            }
        }

        public static IEnumerable<RaceBgm> RaceBgm
        {
            get
            {
                if (raceBgm == null)
                    raceBgm = UmaFileHelper.GetInfoDatabaseRows<RaceBgm>();

                return raceBgm;
            }
        }

        public static IEnumerable<RaceBgmPattern> RaceBgmPatterns
        {
            get
            {
                if (raceBgmPatterns == null)
                    raceBgmPatterns = UmaFileHelper.GetInfoDatabaseRows<RaceBgmPattern>();

                return raceBgmPatterns;
            }
        }

        public static IEnumerable<CharaData> CharaDatas
        {
            get
            {
                if (charaDatas == null)
                    charaDatas = UmaFileHelper.GetInfoDatabaseRows<CharaData>();

                return charaDatas;
            }
        }
    }
}
