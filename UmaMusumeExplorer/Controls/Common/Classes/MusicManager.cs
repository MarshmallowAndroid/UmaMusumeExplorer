using AssetsTools.NET;
using AssetsTools.NET.Extra;
using CriWareLibrary;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeAudio;
using System.Diagnostics;

namespace UmaMusumeExplorer.Controls.Common.Classes
{
    internal class MusicManager
    {
        private readonly Random random = new();

        private readonly int musicId;
        private readonly string cueSheetNameShort = "";
        private readonly string cueSheetNameGameSize = "";

        public MusicManager(LiveData liveData)
        {
            musicId = liveData.MusicId;
        }

        public MusicManager(JukeboxMusicData jukeboxMusicData)
        {
            musicId = jukeboxMusicData.MusicId;
            cueSheetNameShort = jukeboxMusicData.BgmCuesheetNameShort;
            cueSheetNameGameSize = jukeboxMusicData.BgmCuesheetNameGamesize;
        }

        public int MusicId => musicId;

        public List<PartTrigger> PartTriggers { get; } = [];

        public IExtendedSampleProvider? SampleProvider { get; private set; }

        public CharacterPosition[]? CharacterPositions { get; private set; }

        public List<LyricsTrigger> LyricsTriggers { get; } = [];

        public int VoiceTrigger { get; private set; }

        public bool SetupLive(Control parent)
        {
            // Load music score before everything else
            if (!LoadMusicScore()) return ShowMissingResources();

            // Get possible audio assets for music ID
            IEnumerable<ManifestEntry> audioAssetEntries = UmaDataHelper.GetManifestEntries(ga => ga.Name.StartsWith($"sound/l/{musicId}"));

            // Retrieve count of members that actually sing
            int singingMembers = GetSingingMembers();

            // Show unit setup form
            UnitSetupForm unitSetupForm = new(musicId, singingMembers);
            if (ControlHelpers.ShowFormDialogCenter(unitSetupForm, parent) != DialogResult.OK) return false;
            CharacterPositions = unitSetupForm.CharacterPositions;

            // Get BGM with or without sound effects
            int sfx = unitSetupForm.Sfx ? 1 : 2;
            AwbReader? okeAwb = GetAwbFile(audioAssetEntries.FirstOrDefault(aa => aa.BaseName == $"snd_bgm_live_{musicId}_oke_{sfx:d2}.awb"));

            // Legend-Changer has extra variation
            int variation = random.Next(1, 6);
            okeAwb ??= GetAwbFile(audioAssetEntries.FirstOrDefault(
                aa => aa.BaseName == $"snd_bgm_live_{musicId:d4}_oke_{sfx:d2}_{variation:d2}.awb"));

            if (okeAwb is null) return ShowMissingResources();

            // Abort unit setup when character selection is not confirmed
            if (CharacterPositions is null) return false;

            // Add AWB files for the selected characters
            AwbReader[] charaAwbs = new AwbReader[singingMembers];

            // Get character parts
            foreach (var characterPosition in CharacterPositions)
            {
                AwbReader? charaAwb = GetAwbFile(audioAssetEntries.First(aa => aa.BaseName == $"snd_bgm_live_{musicId}_chara_{characterPosition.CharacterId}_01.awb"));
                if (charaAwb is null) return ShowMissingResources();
                charaAwbs[characterPosition.Position] = charaAwb;
            }

            // Initialize song mixer on first playback
            SampleProvider ??= new SongMixer(okeAwb, PartTriggers);
            if (SampleProvider is not SongMixer songMixer) return false;

            // Change background music
            songMixer.ChangeOke(okeAwb);

            // Initialize tracks, can be done during playback
            songMixer.InitializeCharaTracks(charaAwbs);

            // For Legend-Changer
            int mainCharacterId = CharacterPositions.First(p => p.Position == 0).CharacterId;
            int announcerGender = random.Next(1, 3);

            // Voice over for certain Umamusume with either male or female announcer
            AwbReader? voiceOverAwb = GetAwbFile(audioAssetEntries.FirstOrDefault(aa => aa.BaseName == $"snd_bgm_live_{musicId}_vo_{mainCharacterId}_{announcerGender:d2}.awb"));
            voiceOverAwb ??= GetAwbFile(audioAssetEntries.FirstOrDefault(aa => aa.BaseName == $"snd_bgm_live_{musicId}_vo_{0:d4}_{announcerGender:d2}.awb"));

            if (voiceOverAwb is not null)
                songMixer.InitializeVoiceOver(voiceOverAwb, VoiceTrigger);

            // Unit setup success
            return true;
        }

        public bool SetupJukeBoxMusic(SongLength songLength)
        {
            string cueSheetName = "";

            // Select available versions
            if (songLength == SongLength.ShortVersion)
            {
                cueSheetName = cueSheetNameShort;
                if (cueSheetName == string.Empty)
                {
                    MessageBox.Show("Music has no short version. Playing game size version instead.", "No short version", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cueSheetName = cueSheetNameGameSize;
                }
            }
            else
            {
                cueSheetName = cueSheetNameGameSize;
            }

            // Get possible audio assets for music ID
            IEnumerable<ManifestEntry> audioAssetEntries = UmaDataHelper.GetManifestEntries(
                ga => ga.Name.ToLower().Contains(cueSheetName.ToLower() + ".awb"));

            // Get BGM without sound effects
            AwbReader? okeAwb = GetAwbFile(audioAssetEntries.First());

            if (okeAwb is null) return ShowMissingResources();

            // Initialize song mixer on first playback
            SampleProvider ??= new ExtendedSampleProvider(new UmaWaveStream(okeAwb, 0));

            return true;
        }

        private int GetSingingMembers()
        {
            bool[] membersSing = new bool[PartTriggers[0].MemberTracks.Length];

            foreach (var partTrigger in PartTriggers)
            {
                for (int i = 0; i < partTrigger.MemberTracks.Length; i++)
                {
                    if (partTrigger.MemberTracks[i] > 0) membersSing[i] = true;
                }
            }

            int activeMembers = 0;
            for (int i = 0; i < membersSing.Length; i++)
            {
                if (membersSing[i]) activeMembers++;
            }

            return activeMembers;
        }

        //private void CharacterClick(object sender, EventArgs e)
        //{
        //    if (customVoiceControlCheckBox.Checked)
        //    {
        //        CharacterPositionControl character = (sender as Control).Parent as CharacterPositionControl;
        //        int charaIndex = character.PositionIndex - 1;
        //        CharaTrack track = songMixer.CharaTracks[charaIndex];
        //        track.Enabled = !track.Enabled;
        //        singersEnabled[charaIndex] = track.Enabled;
        //    }
        //}

        private bool LoadMusicScore()
        {
            IEnumerable<ManifestEntry> musicScoreAssetEntries = UmaDataHelper.GetManifestEntries(ga => ga.Name.StartsWith($"live/musicscores/m{musicId}"));
            ManifestEntry? timelineEntry = UmaDataHelper.GetManifestEntries(ga => ga.Name.StartsWith($"cutt/cutt_son{musicId}/son{musicId}_camera")).FirstOrDefault();

            if (!musicScoreAssetEntries.Any()) return false;
            if (timelineEntry is null) return false;

            AssetsManager assetsManager = new();
            foreach (var item in musicScoreAssetEntries)
            {
                LoadAsset(assetsManager, item);
            }
            LoadAsset(assetsManager, timelineEntry);

            CsvReader? lyricsCsv = GetLiveCsv(assetsManager, "lyrics");
            if (lyricsCsv is null) return false;
            lyricsCsv.ReadCsvLine();
            while (!lyricsCsv.EndOfStream)
            {
                string line = lyricsCsv.ReadCsvLine();

                if (string.IsNullOrEmpty(line)) continue;

                LyricsTrigger trigger = new(line);
                LyricsTriggers.Add(trigger);
            }

            CsvReader? partCsv = GetLiveCsv(assetsManager, "part");
            if (partCsv is null) return false;
            bool hasVolumeRate = partCsv.ReadCsvLine().Contains("volume_rate");
            while (!partCsv.EndOfStream)
            {
                PartTrigger trigger = new(partCsv.ReadCsvLine(), hasVolumeRate);
                PartTriggers.Add(trigger);
            }

            VoiceTrigger = (int)(GetLiveTimelineData(assetsManager) / 60F * 1000F);

            return true;
        }

        private CsvReader? GetLiveCsv(AssetsManager assetsManager, string category)
        {
            string idString = $"{musicId:d4}";
            string fileName = $"m{idString}_{category}";

            AssetTypeValueField? field = GetAssetBaseField(assetsManager, fileName);
            if (field is not null)
                return new(new MemoryStream(field["m_Script"].AsByteArray));

            return null;
        }

        private int GetLiveTimelineData(AssetsManager assetsManager)
        {
            string idString = $"{musicId:d4}";
            string fileName = $"son{idString}_Camera";

            AssetTypeValueField? field = GetAssetBaseField(assetsManager, fileName);
            if (field is null) return -1;
            field = field["VoiceKeys"]["thisList"][0];
            if (!field.Any()) return -1;
            return field[0]["frame"].AsInt;
        }

        private void LoadAsset(AssetsManager assetsManager, ManifestEntry manifestEntry)
        {
            BundleFileInstance bundle = assetsManager.LoadBundleFile(UmaDataHelper.GetPath(manifestEntry));
            foreach (var assetFileName in bundle.file.GetAllFileNames())
            {
                assetsManager.LoadAssetsFileFromBundle(bundle, assetFileName, false);
            }
        }

        private AssetTypeValueField? GetAssetBaseField(AssetsManager assetsManager, string name)
        {
            foreach (var assetsManagerFile in assetsManager.Files)
            {
                foreach (var asset in assetsManagerFile.file.AssetInfos)
                {
                    AssetTypeValueField baseField = assetsManager.GetBaseField(assetsManagerFile, asset);
                    AssetTypeValueField nameField = baseField["m_Name"];
                    if (nameField.Value?.ValueType == AssetValueType.String)
                        Debug.WriteLine(nameField.AsString);
                    if (nameField.Value?.ValueType == AssetValueType.String && nameField.AsString == name) return baseField;
                }
            }

            return null;
        }

        private static AwbReader? GetAwbFile(ManifestEntry? gameFile)
        {
            if (gameFile is null) return null;

            string awbPath = UmaDataHelper.GetPath(gameFile);
            string cachePath = Path.Combine("LiveCache", gameFile.BaseName);

            string path = awbPath;

            if (!File.Exists(path))
                path = cachePath;

            if (!File.Exists(path))
                return null;
            else
                return new AwbReader(File.OpenRead(path));
        }

        private static bool ShowMissingResources()
        {
            MessageBox.Show("Missing resources for selected music. Please download all resources in the game.", "Missing resources", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }
    }
}
