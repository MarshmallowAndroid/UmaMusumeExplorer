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
        private static IEnumerable<CardData> cardDatas;
        private static IEnumerable<CardRarityData> cardRarityDatas;

        private static IEnumerable<TextData> charaNameTextDatas;
        private static IEnumerable<TextData> charaNameKatakanaTextDatas;
        private static IEnumerable<TextData> charaVoiceNameTextDatas;
        private static IEnumerable<TextData> charaCostumeNameTextDatas;

        public static IEnumerable<GameAsset> BgmGameAssets
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

        public static IEnumerable<CardData> CardDatas
        {
            get
            {
                if (cardDatas == null)
                    cardDatas = UmaFileHelper.GetInfoDatabaseRows<CardData>();

                return cardDatas;
            }
        }

        public static IEnumerable<CardRarityData> CardRarityDatas
        {
            get
            {
                if (cardRarityDatas == null)
                    cardRarityDatas = UmaFileHelper.GetInfoDatabaseRows<CardRarityData>();

                return cardRarityDatas;
            }
        }

        public static IEnumerable<TextData> CharaNameTextDatas
        {
            get
            {
                if (charaNameTextDatas == null)
                    charaNameTextDatas = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 170);

                return charaNameTextDatas;
            }
        }

        public static IEnumerable<TextData> CharaNameKatakanaTextDatas
        {
            get
            {
                if (charaNameKatakanaTextDatas == null)
                    charaNameKatakanaTextDatas = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 182);

                return charaNameKatakanaTextDatas;
            }
        }

        public static IEnumerable<TextData> CharaVoiceNameTextDatas
        {
            get
            {
                if (charaVoiceNameTextDatas == null)
                    charaVoiceNameTextDatas = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 7);

                return charaVoiceNameTextDatas;
            }
        }

        public static IEnumerable<TextData> CharaCostumeNameTextDatas
        {
            get
            {
                if (charaCostumeNameTextDatas == null)
                    charaCostumeNameTextDatas = UmaFileHelper.GetInfoDatabaseRows<TextData>(td => td.Category == 5);

                return charaCostumeNameTextDatas;
            }
        }
    }
}
