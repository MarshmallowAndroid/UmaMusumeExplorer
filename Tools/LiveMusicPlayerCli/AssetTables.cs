using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmamsumeData;
using UmamsumeData.Tables;

namespace LiveMusicPlayerCli
{
    internal static class AssetTables
    {
        public static IEnumerable<ManifestEntry> AudioAssetEntries { get; } = UmaDataHelper.GetManifestEntries(ga => ga.Name.StartsWith("sound/"));

        public static IEnumerable<TextData> CharaNameTextDatas { get; } = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 170);
        public static IEnumerable<TextData> CharaNameKatakanaTextDatas { get; } = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 182);
        public static IEnumerable<TextData> CharaVoiceNameTextDatas { get; } = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 7);
        public static IEnumerable<TextData> CharaCostumeNameTextDatas { get; } = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 5);

        public static IEnumerable<LiveData> LiveDatas { get; } = UmaDataHelper.GetMasterDatabaseRows<LiveData>();
        public static IEnumerable<LivePermissionData> LivePermissionDatas { get; } = UmaDataHelper.GetMasterDatabaseRows<LivePermissionData>();

        public static IEnumerable<TextData> LiveNameTextDatas { get; } = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 16);
        public static IEnumerable<TextData> LiveInfoTextDatas { get; } = UmaDataHelper.GetMasterDatabaseRows<TextData>(td => td.Category == 17);

        public static string GetText(IEnumerable<TextData> textDatas, int index)
        {
            return textDatas.First(td => td.Index == index).Text;
        }
    }
}
