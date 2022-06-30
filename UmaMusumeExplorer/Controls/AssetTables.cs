using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmaMusumeData;
using UmaMusumeData.Tables;

namespace UmaMusumeExplorer.Controls
{
    internal static class AssetTables
    {
        public static IEnumerable<GameAsset> BgmGameAssets => UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("sound/b/"));

        public static IEnumerable<RaceBgm> RaceBgm => UmaDataHelper.GetInfoDatabaseRows<RaceBgm>();

        public static IEnumerable<RaceBgmPattern> RaceBgmPatterns => UmaDataHelper.GetInfoDatabaseRows<RaceBgmPattern>();

        public static IEnumerable<CharaData> CharaDatas => UmaDataHelper.GetInfoDatabaseRows<CharaData>();

        public static IEnumerable<CardData> CardDatas => UmaDataHelper.GetInfoDatabaseRows<CardData>();

        public static IEnumerable<CardRarityData> CardRarityDatas => UmaDataHelper.GetInfoDatabaseRows<CardRarityData>();

        public static IEnumerable<TextData> CharaNameTextDatas => UmaDataHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 170);

        public static IEnumerable<TextData> CharaNameKatakanaTextDatas => UmaDataHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 182);

        public static IEnumerable<TextData> CharaVoiceNameTextDatas => UmaDataHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 7);

        public static IEnumerable<TextData> CharaCostumeNameTextDatas => UmaDataHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 5);
    }
}
