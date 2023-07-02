using AssetStudio;
using CriWareFormats;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class PlayerForm : Form
    {
        private readonly LiveData liveData;
        private readonly int musicId;
        private readonly string songTitle;

        private readonly AssetsManager assetsManager = new();
        private readonly PinnedBitmap songJacketPinnedBitmap;

        private readonly List<LyricsTrigger> lyricsTriggers = new();
        private readonly List<PartTrigger> partTriggers = new();

        private SongMixer songMixer;
        private readonly IWavePlayer waveOut = new WaveOutEvent() { DesiredLatency = 250 };

        private readonly Thread lyricsThread;
        private int lyricsTriggerIndex = 0;
        private bool seeked = false;
        private bool playbackFinished = false;

        private readonly List<string> currentSingers = new();

        public PlayerForm(LiveData live)
        {
            InitializeComponent();

            liveData = live;
            musicId = live.MusicId;

            songJacketPinnedBitmap = UnityAssets.GetJacket(musicId, 'l');
            songJacketPictureBox.BackgroundImage = songJacketPinnedBitmap.Bitmap;
            songTitleLabel.Text = songTitle = AssetTables.GetText(AssetTables.LiveNameTextDatas, musicId);
            songInfoLabel.Text = AssetTables.GetText(AssetTables.LiveInfoTextDatas, musicId).Replace("\\n", "\n");

            LoadMusicScore();

            lyricsThread = new(DoLyricsPlayback);

            Icon = Icon.FromHandle(songJacketPinnedBitmap.Bitmap.GetHicon());
        }

        private void LiveMusicPlayerForm_Load(object sender, EventArgs e)
        {
            if (!SetupUnit())
            {
                Close();
                return;
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (lyricsThread.ThreadState.HasFlag(ThreadState.Unstarted))
                lyricsThread.Start();

            if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Pause();
            }
            else
            {
                waveOut.Play();
            }

            updateTimer.Enabled = waveOut.PlaybackState == PlaybackState.Playing;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            currentTimeLabel.Text = $"{songMixer.CurrentTime:m\\:ss}";
            seekTrackBar.Value = (int)(songMixer.CurrentTime / songMixer.TotalTime * 100.0F);
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            songJacketPinnedBitmap.Dispose();
            playbackFinished = true;

            waveOut.Stop();
            waveOut.Dispose();

            assetsManager.Clear();
        }

        private void SeekTrackBar_Scroll(object sender, EventArgs e)
        {
            songMixer.Position = (long)(songMixer.Length * (float)(seekTrackBar.Value / 100.0F));
            seeked = true;
        }

        private void VolumeTrackbar_Scroll(object sender, EventArgs e)
        {
            waveOut.Volume = volumeTrackbar.Value / 100.0F;
            volumeLabel.Text = (int)Math.Ceiling(waveOut.Volume * 100.0F) + "%";
        }

        private void SetupButton_Click(object sender, EventArgs e)
        {
            SetupUnit();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            waveOut.Stop();
            waveOut.Dispose();
            songMixer.Dispose();
            Close();
        }

        private void ForceSoloMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            songMixer.CenterOnly = item.Checked;

            if (forceAllSingingMenuItem.Checked) forceAllSingingMenuItem.Checked = false;
            songMixer.AllSing = forceAllSingingMenuItem.Checked;
        }

        private void ForceAllSingingMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            songMixer.AllSing = item.Checked;

            if (forceSoloMenuItem.Checked) forceSoloMenuItem.Checked = false;
            songMixer.CenterOnly = forceSoloMenuItem.Checked;
        }

        private void MuteBgmMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            songMixer.MuteBgm = item.Checked;

            if (muteVoicesMenuItem.Checked) muteVoicesMenuItem.Checked = false;
            songMixer.MuteVoices = muteVoicesMenuItem.Checked;
        }

        private void MuteVoicesMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            songMixer.MuteVoices = item.Checked;

            if (muteBgmMenuItem.Checked) muteBgmMenuItem.Checked = false;
            songMixer.MuteBgm = muteBgmMenuItem.Checked;
        }

        private void ExportMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder fileNameString = new();
            fileNameString.Append(songTitle + " (");
            for (int i = 0; i < currentSingers.Count; i++)
            {
                fileNameString.Append(currentSingers[i]);

                if (songMixer.CenterOnly) break;
                if (i < currentSingers.Count - 1) fileNameString.Append('・');
            }
            fileNameString.Append(").wav");

            SaveFileDialog saveFileDialog = new()
            {
                FileName = fileNameString.ToString(),
                Filter = "16-bit PCM WAV|*.wav"
            };

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PlaybackState playbackState = waveOut.PlaybackState;
                waveOut.Pause();

                Task.Run(() =>
                {
                    long restorePosition = songMixer.Position;
                    string restoreInfo = songInfoLabel.Text;

                    songMixer.Position = 0;
                    lyricsTriggerIndex = 0;
                    Invoke(() =>
                    {
                        songInfoLabel.Text = "Exporting...";
                        setupButton.Enabled = false;
                        playButton.Enabled = false;
                        stopButton.Enabled = false;
                        updateTimer.Enabled = true;
                    });

                    WaveFileWriter.CreateWaveFile16(saveFileDialog.FileName, songMixer);

                    songMixer.Position = restorePosition;
                    lyricsTriggerIndex = 0;

                    if (playbackState == PlaybackState.Playing)
                        waveOut.Play();

                    Invoke(() =>
                    {
                        songInfoLabel.Text = restoreInfo;
                        setupButton.Enabled = true;
                        playButton.Enabled = true;
                        stopButton.Enabled = true;
                        updateTimer.Enabled = waveOut.PlaybackState == PlaybackState.Playing;
                    });
                });
            }
        }

        private int GetSingingMembers()
        {
            bool[] membersSing = new bool[partTriggers[0].MemberTracks.Length];

            foreach (var partTrigger in partTriggers)
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

        private bool SetupUnit()
        {
            // Get possible audio assets for music ID
            IEnumerable<GameAsset> audioAssets = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith($"sound/l/{musicId}"));

            // Get BGM without sound effects
            AwbReader okeAwb = GetAwbFile(audioAssets.First(aa => aa.BaseName.Equals($"snd_bgm_live_{musicId}_oke_02.awb")));

            if (okeAwb is null) return ShowFileNotFound();

            // Retrieve count of members that actually sing
            int singingMembers = GetSingingMembers();

            // Launch unit setup
            UnitSetupForm unitSetupForm = new(musicId, singingMembers);
            unitSetupForm.Text = songTitleLabel.Text + " " + unitSetupForm.Text;
            ControlHelpers.ShowFormDialogCenter(unitSetupForm, this);

            // Abort unit setup when character selection is not confirmed
            if (unitSetupForm.CharacterPositions is null) return false;

            // Sort by position indices
            Array.Sort(unitSetupForm.CharacterPositions, (a, b) => a.PositionIndex.CompareTo(b.PositionIndex));

            currentSingers.Clear();

            // Add AWB files for the selected characters
            List<AwbReader> charaAwbs = new(singingMembers);
            foreach (var item in unitSetupForm.CharacterPositions)
            {
                AwbReader charaAwb = GetAwbFile(audioAssets.First(aa => aa.BaseName.Equals($"snd_bgm_live_{musicId}_chara_{item.CharacterId}_01.awb")));

                if (charaAwb is null) return ShowFileNotFound();

                charaAwbs.Add(charaAwb);
                currentSingers.Add(AssetTables.GetText(AssetTables.CharaNameTextDatas, item.CharacterId));
            }

            long previousPosition = songMixer?.Position ?? 0;

            // Initialize song mixer on first playback
            if (songMixer is null)
            {
                songMixer = new(okeAwb, partTriggers);
                waveOut.Init(songMixer);

                waveOut.Play();

                lyricsThread.Start();
                updateTimer.Enabled = true;
            }

            // Initialize tracks, can be done during playback
            songMixer.InitializeCharaTracks(charaAwbs);

            // Update the total time and volume track bars
            totalTimeLabel.Text = $"{songMixer.TotalTime:m\\:ss}";
            int volume = (int)Math.Ceiling(waveOut.Volume * 100.0F);
            volumeTrackbar.Value = volume;
            volumeLabel.Text = volume + "%";

            // Unit setup success
            return true;
        }

        private bool ShowFileNotFound()
        {
            MessageBox.Show("Live music data not found. Please download all resources in the game.", "Assets not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        private void LoadMusicScore()
        {
            IEnumerable<GameAsset> musicScoreAssets = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith($"live/musicscores/m{liveData.MusicId}"));

            if (!musicScoreAssets.Any()) return;

            List<string> assetPaths = new();
            foreach (var item in musicScoreAssets)
            {
                assetPaths.Add(UmaDataHelper.GetPath(item));
            }
            assetsManager.LoadFiles(assetPaths.ToArray());

            CsvReader lyricsCsv = GetLiveCsv(liveData.MusicId, "lyrics");
            lyricsCsv.ReadCsvLine();
            while (!lyricsCsv.EndOfStream)
            {
                LyricsTrigger trigger = new(lyricsCsv.ReadCsvLine());
                lyricsTriggers.Add(trigger);
            }

            CsvReader partCsv = GetLiveCsv(liveData.MusicId, "part");
            bool hasVolumeRate = partCsv.ReadCsvLine().Contains("volume_rate");
            while (!partCsv.EndOfStream)
            {
                PartTrigger trigger = new(partCsv.ReadCsvLine(), hasVolumeRate);
                partTriggers.Add(trigger);
            }
        }

        private CsvReader GetLiveCsv(int musicId, string category)
        {
            string idString = $"{musicId:d4}";

            SerializedFile targetAsset = assetsManager.assetsFileList.FirstOrDefault(
                a => (a.Objects.FirstOrDefault(o => o.type == ClassIDType.TextAsset) as NamedObject)?.m_Name.Equals($"m{idString}_{category}") ?? false);
            if (targetAsset is null) return null;
            TextAsset textAsset = targetAsset.Objects.First(o => o.type == ClassIDType.TextAsset) as TextAsset;

            return new CsvReader(new MemoryStream(textAsset.m_Script));
        }

        private void DoLyricsPlayback()
        {
            while (!playbackFinished)
            {
                double msElapsed = songMixer.CurrentTime.TotalMilliseconds;

                if (seeked)
                {
                    lyricsTriggerIndex = 0;
                    seeked = false;
                }

                while (msElapsed >= lyricsTriggers[lyricsTriggerIndex].TimeMs)
                {
                    TryInvoke(() =>
                    {
                        lyricsLabel.Text = lyricsTriggers[lyricsTriggerIndex].Lyrics.Replace("&", "&&");
                    });

                    if (lyricsTriggerIndex < lyricsTriggers.Count - 1)
                        lyricsTriggerIndex++;
                    else break;
                }

                Thread.Sleep(1);
            }
        }

        private static AwbReader GetAwbFile(GameAsset gameFile)
        {
            string awbPath = UmaDataHelper.GetPath(gameFile);
            if (File.Exists(awbPath))
                return new(File.OpenRead(awbPath));
            else
                return null;
        }

        private void TryInvoke(Action action)
        {
            try
            {
                Invoke(action);
            }
            catch (Exception)
            {
            }
        }
    }
}
