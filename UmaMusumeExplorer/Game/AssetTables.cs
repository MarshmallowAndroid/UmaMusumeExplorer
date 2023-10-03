using UmaMusumeData;
using UmaMusumeData.Tables;

namespace UmaMusumeExplorer.Game
{
    static class AssetTables
    {
        public static void Initialize()
        {
            List<LoadAction> initializeActions = new()
            {
                () => { AudioAssets.AddRange(UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("sound/"))); return "AudioAssets"; },

                () => { AvailableSkillSets.AddRange(UmaDataHelper.GetMasterDatabaseRows<AvailableSkillSet>()); return "AvailableSkillSets"; },

                () => { CardDatas.AddRange(UmaDataHelper.GetMasterDatabaseRows<CardData>()); return "CardDatas"; },
                () => { CardRarityDatas.AddRange(UmaDataHelper.GetMasterDatabaseRows<CardRarityData>()); return "CardRarityDatas"; },
                () => { CharaDatas.AddRange(UmaDataHelper.GetMasterDatabaseRows<CharaData>()); return "CharaDatas"; },

                () => { CharacterSystemTexts.AddRange(UmaDataHelper.GetMasterDatabaseRows<CharacterSystemText>()); return "CharacterSystemTexts"; },

                () => { JukeboxMusicDatas.AddRange(UmaDataHelper.GetMasterDatabaseRows<JukeboxMusicData>()); return "JukeboxMusicDatas"; },

                () => { LiveDatas.AddRange(UmaDataHelper.GetMasterDatabaseRows<LiveData>()); return "LiveDatas"; },
                () => { LivePermissionDatas.AddRange(UmaDataHelper.GetMasterDatabaseRows<LivePermissionData>()); return "LivePermissionDatas"; },

                () => { RaceBgm.AddRange(UmaDataHelper.GetMasterDatabaseRows<RaceBgm>()); return "RaceBgm"; },
                () => { RaceBgmPatterns.AddRange(UmaDataHelper.GetMasterDatabaseRows<RaceBgmPattern>()); return "RaceBgmPatterns"; },

                () => { SkillSets.AddRange(UmaDataHelper.GetMasterDatabaseRows<SkillSet>()); return "SkillSets"; },
                () => { SkillDatas.AddRange(UmaDataHelper.GetMasterDatabaseRows<SkillData>()); return "SkillDatas"; },

                () => { SingleModeSkillNeedPoints.AddRange(UmaDataHelper.GetMasterDatabaseRows<SingleModeSkillNeedPoint>()); return "SingleModeSkillNeedPoints"; },

                () => { SkillUpgradeConditions.AddRange(UmaDataHelper.GetMasterDatabaseRows<SkillUpgradeCondition>()); return "SkillUpgradeConditions"; },
                () => { SkillUpgradeDescriptions.AddRange(UmaDataHelper.GetMasterDatabaseRows<SkillUpgradeDescription>()); return "SkillUpgradeDescriptions"; },

                () => { TextData.AddRange(UmaDataHelper.GetMasterDatabaseRows<TextData>()); return "TextData"; }
            };

            int completedActions = 0;
            foreach (var action in initializeActions)
            {
                string name = action.Invoke();
                UpdateProgress?.Invoke((int)((float)++completedActions / initializeActions.Count * 100), name);
            }
        }

        public delegate string LoadAction();

        public delegate void ProgressUpdater(int progress, string loadedName);

        public static ProgressUpdater? UpdateProgress { get; set; }

        public static List<GameAsset> AudioAssets { get; private set; } = new();

        public static List<AvailableSkillSet> AvailableSkillSets { get; private set; } = new();

        public static List<CardData> CardDatas { get; private set; } = new();
        public static List<CardRarityData> CardRarityDatas { get; private set; } = new();
        public static List<CharaData> CharaDatas { get; private set; } = new();

        public static List<CharacterSystemText> CharacterSystemTexts { get; private set; } = new();

        public static List<JukeboxMusicData> JukeboxMusicDatas { get; private set; } = new();

        public static List<LiveData> LiveDatas { get; private set; } = new();
        public static List<LivePermissionData> LivePermissionDatas { get; private set; } = new();

        public static List<RaceBgm> RaceBgm { get; private set; } = new();
        public static List<RaceBgmPattern> RaceBgmPatterns { get; private set; } = new();

        public static List<SkillSet> SkillSets { get; private set; } = new();
        public static List<SkillData> SkillDatas { get; private set; } = new();

        public static List<SingleModeSkillNeedPoint> SingleModeSkillNeedPoints { get; private set; } = new();

        public static List<SkillUpgradeCondition> SkillUpgradeConditions { get; private set; } = new();
        public static List<SkillUpgradeDescription> SkillUpgradeDescriptions { get; private set; } = new();

        public static List<TextData> TextData { get; private set; } = new();

        public static string GetText(TextCategory category, int index)
        {
            return TextData.First(td => td.Category == (int)category && td.Index == index).Text;
        }
    }
}
