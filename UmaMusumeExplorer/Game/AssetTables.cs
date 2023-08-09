using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
                () => { AudioAssets = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("sound/")); return "AudioAssets"; },

                () => { AvailableSkillSets = UmaDataHelper.GetMasterDatabaseRows<AvailableSkillSet>(); return "AvailableSkillSets"; },

                () => { CardDatas = UmaDataHelper.GetMasterDatabaseRows<CardData>(); return "CardDatas"; },
                () => { CardRarityDatas = UmaDataHelper.GetMasterDatabaseRows<CardRarityData>(); return "CardRarityDatas"; },
                () => { CharaDatas = UmaDataHelper.GetMasterDatabaseRows<CharaData>(); return "CharaDatas"; },

                () => { CharacterSystemTexts = UmaDataHelper.GetMasterDatabaseRows<CharacterSystemText>(); return "CharacterSystemTexts"; },

                () => { JukeboxMusicDatas = UmaDataHelper.GetMasterDatabaseRows<JukeboxMusicData>(); return "JukeboxMusicDatas"; },

                () => { LiveDatas = UmaDataHelper.GetMasterDatabaseRows<LiveData>(); return "LiveDatas"; },
                () => { LivePermissionDatas = UmaDataHelper.GetMasterDatabaseRows<LivePermissionData>(); return "LivePermissionDatas"; },

                () => { RaceBgm = UmaDataHelper.GetMasterDatabaseRows<RaceBgm>(); return "RaceBgm"; },
                () => { RaceBgmPatterns = UmaDataHelper.GetMasterDatabaseRows<RaceBgmPattern>(); return "RaceBgmPatterns"; },

                () => { SkillSets = UmaDataHelper.GetMasterDatabaseRows<SkillSet>(); return "SkillSets"; },
                () => { SkillDatas = UmaDataHelper.GetMasterDatabaseRows<SkillData>(); return "SkillDatas"; },

                () => { SingleModeSkillNeedPoints = UmaDataHelper.GetMasterDatabaseRows<SingleModeSkillNeedPoint>(); return "SingleModeSkillNeedPoints"; },

                () => { SkillUpgradeConditions = UmaDataHelper.GetMasterDatabaseRows<SkillUpgradeCondition>(); return "SkillUpgradeConditions"; },
                () => { SkillUpgradeDescriptions = UmaDataHelper.GetMasterDatabaseRows<SkillUpgradeDescription>(); return "SkillUpgradeDescriptions"; },

                () => { TextData = UmaDataHelper.GetMasterDatabaseRows<TextData>(); return "TextData"; }
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

        public static ProgressUpdater UpdateProgress { get; set; }

        public static IEnumerable<GameAsset> AudioAssets { get; private set; }

        public static IEnumerable<AvailableSkillSet> AvailableSkillSets { get; private set; }

        public static IEnumerable<CardData> CardDatas { get; private set; }
        public static IEnumerable<CardRarityData> CardRarityDatas { get; private set; }
        public static IEnumerable<CharaData> CharaDatas { get; private set; }

        public static IEnumerable<CharacterSystemText> CharacterSystemTexts { get; private set; }

        public static IEnumerable<JukeboxMusicData> JukeboxMusicDatas { get; private set; }

        public static IEnumerable<LiveData> LiveDatas { get; private set; }
        public static IEnumerable<LivePermissionData> LivePermissionDatas { get; private set; }

        public static IEnumerable<RaceBgm> RaceBgm { get; private set; }
        public static IEnumerable<RaceBgmPattern> RaceBgmPatterns { get; private set; }

        public static IEnumerable<SkillSet> SkillSets { get; private set; }
        public static IEnumerable<SkillData> SkillDatas { get; private set; }

        public static IEnumerable<SingleModeSkillNeedPoint> SingleModeSkillNeedPoints { get; private set; }

        public static IEnumerable<SkillUpgradeCondition> SkillUpgradeConditions { get; private set; }
        public static IEnumerable<SkillUpgradeDescription> SkillUpgradeDescriptions { get; private set; }

        public static IEnumerable<TextData> TextData { get; private set; }

        public static string GetText(TextCategory category, int index)
        {
            return TextData.First(td => td.Category == (int)category && td.Index == index).Text;
        }
    }
}
