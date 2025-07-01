using System.Reflection;
using System.Runtime.CompilerServices;
using UmaMusumeData;
using UmaMusumeData.Tables;

namespace UmaMusumeExplorer.Game
{
    static class AssetTables
    {
        public static void Initialize()
        {
            Type assetTablesType = typeof(AssetTables);
            IEnumerable<PropertyInfo> properties = assetTablesType.GetProperties().Where(p => p.PropertyType.Name == "List`1");

            Queue<LoadAction> customLoadAction = new();
            customLoadAction.Enqueue(() => { AudioAssetEntries.AddRange(UmaDataHelper.GetManifestEntries(ga => ga.Name.StartsWith("sound/"))); return "AudioAssetEntries"; });

            int completed = 0;
            foreach (var property in properties)
            {
                Type listType = property.PropertyType.GenericTypeArguments[0];

                string name = property.Name;
                if (name == (listType.Name + "s"))
                {
                    MethodInfo? targetMethod = (typeof(UmaDataHelper).GetMethod("GetMasterDatabaseRows")?.MakeGenericMethod(listType)) ??
                        throw new Exception("Could not find suitable method.");
                    property.SetValue(null, targetMethod.Invoke(null, [null]));
                }
                else
                {
                    name = customLoadAction.Dequeue().Invoke();
                }

                UpdateProgress?.Invoke((int)((float)++completed / properties.Count() * 100), name);
            }
        }

        public delegate string LoadAction();

        public delegate void ProgressUpdater(int progress, string loadedName);

        public static ProgressUpdater? UpdateProgress { get; set; }

        public static List<ManifestEntry> AudioAssetEntries { get; private set; } = [];

        public static List<AvailableSkillSet> AvailableSkillSets { get; private set; } = [];

        public static List<CardData> CardDatas { get; private set; } = [];
        public static List<CardRarityData> CardRarityDatas { get; private set; } = [];
        public static List<CharaData> CharaDatas { get; private set; } = [];

        public static List<CharacterSystemText> CharacterSystemTexts { get; private set; } = [];

        public static List<GachaAvailable> GachaAvailables { get; private set; } = [];

        public static List<JukeboxMusicData> JukeboxMusicDatas { get; private set; } = [];

        public static List<LiveData> LiveDatas { get; private set; } = [];
        public static List<LivePermissionData> LivePermissionDatas { get; private set; } = [];

        public static List<RaceBgm> RaceBgms { get; private set; } = [];
        public static List<RaceBgmPattern> RaceBgmPatterns { get; private set; } = [];

        public static List<SkillSet> SkillSets { get; private set; } = [];
        public static List<SkillData> SkillDatas { get; private set; } = [];

        public static List<SingleModeSkillNeedPoint> SingleModeSkillNeedPoints { get; private set; } = [];

        public static List<SkillUpgradeCondition> SkillUpgradeConditions { get; private set; } = [];
        public static List<SkillUpgradeDescription> SkillUpgradeDescriptions { get; private set; } = [];

        public static List<SupportCardData> SupportCardDatas { get; private set; } = [];

        public static List<TextData> TextDatas { get; private set; } = [];

        public static string GetText(TextCategory category, int index)
        {
            return TextDatas.First(td => td.Category == (int)category && td.Index == index).Text;
        }
    }
}
