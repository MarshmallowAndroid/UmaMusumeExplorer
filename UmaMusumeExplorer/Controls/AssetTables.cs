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
        private static readonly IEnumerable<GameAsset> bgmGameFiles = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("sound/b/"));

        private static readonly IEnumerable<CardData> cardDatas = UmaDataHelper.GetMasterDatabaseRows<CardData>();
        private static readonly IEnumerable<CardRarityData> cardRarityDatas = UmaDataHelper.GetMasterDatabaseRows<CardRarityData>();
        private static readonly IEnumerable<CharaData> charaDatas = UmaDataHelper.GetMasterDatabaseRows<CharaData>();

        private static readonly IEnumerable<LiveData> liveDatas = UmaDataHelper.GetMasterDatabaseRows<LiveData>();
        private static readonly IEnumerable<LivePermissionData> livePermissionDatas = UmaDataHelper.GetMasterDatabaseRows<LivePermissionData>();

        private static readonly IEnumerable<RaceBgm> raceBgm = UmaDataHelper.GetMasterDatabaseRows<RaceBgm>();
        private static readonly IEnumerable<RaceBgmPattern> raceBgmPatterns = UmaDataHelper.GetMasterDatabaseRows<RaceBgmPattern>();

        private static readonly IEnumerable<TextData> charaNameTextDatas = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 170);
        private static readonly IEnumerable<TextData> charaNameKatakanaTextDatas = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 182);
        private static readonly IEnumerable<TextData> charaVoiceNameTextDatas = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 7);
        private static readonly IEnumerable<TextData> charaCostumeNameTextDatas = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 5);

        private static readonly IEnumerable<TextData> liveNameTextDatas = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 16);

        public static IEnumerable<GameAsset> BgmGameAssets => bgmGameFiles;
        
        public static IEnumerable<CardData> CardDatas => cardDatas;
        public static IEnumerable<CardRarityData> CardRarityDatas => cardRarityDatas;
         public static IEnumerable<CharaData> CharaDatas => charaDatas;

        public static IEnumerable<LiveData> LiveDatas => liveDatas;
        public static IEnumerable<LivePermissionData> LivePermissionDatas => livePermissionDatas;
        
        public static IEnumerable<RaceBgm> RaceBgm => raceBgm;
        public static IEnumerable<RaceBgmPattern> RaceBgmPatterns => raceBgmPatterns;

        public static IEnumerable<TextData> CharaCostumeNameTextDatas => charaCostumeNameTextDatas;     
        public static IEnumerable<TextData> CharaNameKatakanaTextDatas => charaNameKatakanaTextDatas;
        public static IEnumerable<TextData> CharaNameTextDatas => charaNameTextDatas;
        public static IEnumerable<TextData> CharaVoiceNameTextDatas => charaVoiceNameTextDatas;

    }
}
