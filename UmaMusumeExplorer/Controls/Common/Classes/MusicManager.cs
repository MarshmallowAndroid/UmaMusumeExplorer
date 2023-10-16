using AssetsTools.NET;
using AssetsTools.NET.Extra;
using CriWareLibrary;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.LiveMusicPlayer;
using UmaMusumeAudio;

namespace UmaMusumeExplorer.Controls.Common.Classes
{
    internal class MusicManager
    {
        public MusicManager(LiveData liveData)
        {
            MusicId = liveData.MusicId;
            LoadMusicScore();
        }

        public MusicManager(JukeboxMusicData jukeboxMusicData, SongLength songLength)
        {
            MusicId = jukeboxMusicData.MusicId;
            LoadJukeBoxMusic(jukeboxMusicData, songLength);
        }

        public int MusicId { get; }

        public List<PartTrigger> PartTriggers { get; } = new();

        public IExtendedSampleProvider? SampleProvider { get; private set; }

        public CharacterPosition[]? CharacterPositions { get; private set; }

        public List<LyricsTrigger> LyricsTriggers { get; } = new();

        public bool SetupLive(Control parent)
        {
            // Get possible audio assets for music ID
            IEnumerable<ManifestEntry> audioAssetEntries = UmaDataHelper.GetManifestEntryDataRows(ga => ga.Name.StartsWith($"sound/l/{MusicId}"));

            // Retrieve count of members that actually sing
            int singingMembers = GetSingingMembers();

            // Show unit setup form
            UnitSetupForm unitSetupForm = new(MusicId, singingMembers);
            ControlHelpers.ShowFormDialogCenter(unitSetupForm, parent);
            CharacterPositions = unitSetupForm.CharacterPositions;

            // Get BGM with or without sound effects
            AwbReader? okeAwb = GetAwbFile(audioAssetEntries.First(aa => aa.BaseName == $"snd_bgm_live_{MusicId}_oke_0{(unitSetupForm.Sfx ? '1' : '2')}.awb"));
            if (okeAwb is null) return ShowFileNotFound();

            // Abort unit setup when character selection is not confirmed
            if (CharacterPositions is null) return false;

            // Add characters position controls to voice control panel
            //charaContainerPanel.Controls.Clear();
            //foreach (var characterPosition in unitSetupForm.CharacterPositions)
            //{
            //    charaContainerPanel.Controls.Add(`
            //        new CharacterPositionControl(characterPosition.PositionIndex, CharacterClick)
            //        {
            //            CharacterId = characterPosition.CharacterId,
            //            FontSize = 12F,
            //            Height = 140,
            //            PositionIndex = characterPosition.PositionIndex,
            //            Width = 70
            //        });
            //}

            //CharacterPosition[] sortedPositions = CharacterPositions.Clone() as CharacterPosition[];

            // Sort by position indices
            //Array.Sort(sortedPositions, (a, b) => a.Position.CompareTo(b.Position));

            // Add AWB files for the selected characters
            AwbReader[] charaAwbs = new AwbReader[singingMembers];

            foreach (var characterPosition in CharacterPositions)
            {
                AwbReader? charaAwb = GetAwbFile(audioAssetEntries.First(aa => aa.BaseName == $"snd_bgm_live_{MusicId}_chara_{characterPosition.CharacterId}_01.awb"));
                if (charaAwb is null) return ShowFileNotFound();
                charaAwbs[characterPosition.Position] = charaAwb;
            }

            // Initialize song mixer on first playback
            SongMixer songMixer = new(okeAwb, PartTriggers);

            if (SampleProvider is null)
            {
                SampleProvider = songMixer;
            }
            else // Otherwise, change background music
                songMixer.ChangeOke(okeAwb);

            // Initialize tracks, can be done during playback
            songMixer.InitializeCharaTracks(charaAwbs);

            // Unit setup success
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

        private void LoadMusicScore()
        {
            IEnumerable<ManifestEntry> musicScoreAssetEntries = UmaDataHelper.GetManifestEntryDataRows(ga => ga.Name.StartsWith($"live/musicscores/m{MusicId}"));

            if (!musicScoreAssetEntries.Any()) return;

            AssetsManager assetsManager = new();
            foreach (var item in musicScoreAssetEntries)
            {
                BundleFileInstance bundle = assetsManager.LoadBundleFile(UmaDataHelper.GetPath(item));

                foreach (var assetFileName in bundle.file.GetAllFileNames())
                {
                    assetsManager.LoadAssetsFileFromBundle(bundle, assetFileName, false);
                }
            }

            CsvReader? lyricsCsv = GetLiveCsv(assetsManager, "lyrics");
            if (lyricsCsv is not null)
            {
                lyricsCsv.ReadCsvLine();
                while (!lyricsCsv.EndOfStream)
                {
                    string line = lyricsCsv.ReadCsvLine();

                    if (string.IsNullOrEmpty(line)) continue;

                    LyricsTrigger trigger = new(line);
                    LyricsTriggers.Add(trigger);
                }
            }

            CsvReader? partCsv = GetLiveCsv(assetsManager, "part");
            if (partCsv is not null)
            {
                bool hasVolumeRate = partCsv.ReadCsvLine().Contains("volume_rate");
                while (!partCsv.EndOfStream)
                {
                    PartTrigger trigger = new(partCsv.ReadCsvLine(), hasVolumeRate);
                    PartTriggers.Add(trigger);
                }
            }
        }

        private void LoadJukeBoxMusic(JukeboxMusicData jukeboxMusicData, SongLength songLength)
        {
            string cueSheetName = "";

            if (songLength == SongLength.ShortVersion)
            {
                cueSheetName = jukeboxMusicData.BgmCuesheetNameShort;

                if (cueSheetName == string.Empty)
                {
                    MessageBox.Show("Music has no short version. Playing game size version instead.", "No short version", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cueSheetName = jukeboxMusicData.BgmCuesheetNameGamesize;
                }
            }
            else
            {
                cueSheetName = jukeboxMusicData.BgmCuesheetNameGamesize;
            }

            // Get possible audio assets for music ID
            IEnumerable<ManifestEntry> audioAssetEntries = UmaDataHelper.GetManifestEntryDataRows(
                ga => ga.Name.ToLower().Contains(cueSheetName.ToLower() + ".awb"));

            // Get BGM without sound effects
            AwbReader? okeAwb = GetAwbFile(audioAssetEntries.First());

            if (okeAwb is null)
            {
                ShowFileNotFound();
                return;
            }

            // Initialize song mixer on first playback
            SampleProvider ??= new ExtendedSampleProvider(new UmaWaveStream(okeAwb, 0));
        }

        private CsvReader? GetLiveCsv(AssetsManager assetsManager, string category)
        {
            string idString = $"{MusicId:d4}";
            string fileName = $"m{idString}_{category}";

            foreach (var assetsManagerFile in assetsManager.Files)
            {
                foreach (var asset in assetsManagerFile.file.AssetInfos)
                {
                    AssetTypeValueField baseField = assetsManager.GetBaseField(assetsManagerFile, asset);
                    if (baseField["m_Name"].AsString == fileName)
                        return new(new MemoryStream(baseField["m_Script"].AsByteArray));
                }
            }

            return null;
        }

        private static AwbReader? GetAwbFile(ManifestEntry gameFile)
        {
            string awbPath = UmaDataHelper.GetPath(gameFile);
            if (File.Exists(awbPath))
                return new(File.OpenRead(awbPath));
            else
                return null;
        }

        private static bool ShowFileNotFound()
        {
            MessageBox.Show("Music data not found. Please download all resources in the game.", "Asset not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }
    }
}
