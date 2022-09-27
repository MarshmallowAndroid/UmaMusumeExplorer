using AssetStudio;
using CriWareFormats;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeAudio;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.Jukebox;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    public partial class PlayerForm : Form
    {
        private readonly LiveData liveData;
        private readonly int musicId;

        private readonly AssetsManager assetsManager = new();
        private PinnedBitmap songJacketPinnedBitmap;

        private readonly List<LyricsTrigger> lyricsTriggers = new();
        private readonly List<PartTrigger> partTriggers = new();

        private SongMixer songMixer;
        private readonly WaveOutEvent waveOutEvent = new() { DesiredLatency = 250 };

        private readonly Thread lyricsThread;
        private int lyricsTriggerIndex = 0;
        private bool seeked = false;
        private bool playbackFinished = false;

        public PlayerForm(LiveData live)
        {
            InitializeComponent();

            liveData = live;
            musicId = live.MusicId;

            LoadMusicScore();

            lyricsThread = new(DoLyricsPlayback);
        }

        private void LiveMusicPlayerForm_Load(object sender, EventArgs e)
        {
            songJacketPinnedBitmap = UnityAssetHelpers.GetJacket(musicId, 'l');
            songJacketPictureBox.BackgroundImage = songJacketPinnedBitmap.Bitmap;
            songTitleLabel.Text = AssetTables.LiveNameTextDatas.First(litd => litd.Index == musicId).Text;
            songInfoLabel.Text = AssetTables.LiveInfoTextDatas.First(litd => litd.Index == musicId).Text.Replace("\\n", "\n");

            if (!SetupUnit())
            {
                Close();
                return;
            }

            new LightsForm(musicId, songMixer).Show();
        }

        private bool SetupUnit()
        {
            // Get possible audio assets for music ID
            IEnumerable<GameAsset> audioAssets = UmaDataHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith($"sound/l/{musicId}"));

            // Get BGM without sound effects
            AwbReader okeAwb = GetAwbFile(audioAssets.First(aa => aa.BaseName.Equals($"snd_bgm_live_{musicId}_oke_02.awb")));

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

            // Add AWB files for the selected characters
            List<AwbReader> charaAwbs = new(singingMembers);
            foreach (var item in unitSetupForm.CharacterPositions)
            {
                charaAwbs.Add(GetAwbFile(audioAssets.First(aa => aa.BaseName.Equals($"snd_bgm_live_{musicId}_chara_{item.CharacterId}_01.awb"))));
            }

            long previousPosition = songMixer?.Position ?? 0;

            // Initialize song mixer on first playback
            if (songMixer is null)
            {
                songMixer = new(okeAwb, partTriggers);
                waveOutEvent.Init(songMixer);
            }

            // Initialize tracks, can be done during playback
            songMixer.InitializeCharaTracks(charaAwbs);

            // Update the total time and volume track bars
            totalTimeLabel.Text = $"{songMixer.TotalTime:m\\:ss}";
            int volume = (int)Math.Ceiling(waveOutEvent.Volume * 100.0f);
            volumeTrackbar.Value = volume;
            volumeLabel.Text = volume + "%";

            // Unit setup success
            return true;
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

            StreamReader lyricsCsv = GetLiveCsv(liveData.MusicId, "lyrics");
            lyricsCsv.ReadLine();
            while (!lyricsCsv.EndOfStream)
            {
                LyricsTrigger trigger = new(lyricsCsv.ReadLine());
                lyricsTriggers.Add(trigger);
            }

            StreamReader partCsv = GetLiveCsv(liveData.MusicId, "part");
            bool hasVolumeRate = partCsv.ReadLine().Contains("volume_rate");
            while (!partCsv.EndOfStream)
            {
                PartTrigger trigger = new(partCsv.ReadLine(), hasVolumeRate);
                partTriggers.Add(trigger);
            }
        }

        private StreamReader GetLiveCsv(int musicId, string category)
        {
            string idString = $"{musicId:d4}";

            SerializedFile targetAsset = assetsManager.assetsFileList.Where(
                a => (a.Objects.Where(o => o.type == ClassIDType.TextAsset).FirstOrDefault() as NamedObject)?.m_Name.Equals($"m{idString}_{category}") ?? false).FirstOrDefault();
            if (targetAsset is null) return null;
            TextAsset textAsset = targetAsset.Objects.Where(o => o.type == ClassIDType.TextAsset).First() as TextAsset;

            return new StreamReader(new MemoryStream(textAsset.m_Script));
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (lyricsThread.ThreadState.HasFlag(ThreadState.Unstarted))
                lyricsThread.Start();

            if (waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                waveOutEvent.Pause();
            }
            else
            {
                waveOutEvent.Play();
            }

            updateTimer.Enabled = waveOutEvent.PlaybackState == PlaybackState.Playing;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            currentTimeLabel.Text = $"{songMixer.CurrentTime:m\\:ss}";
            seekTrackBar.Value = (int)(songMixer.CurrentTime / songMixer.TotalTime * 100.0d);
        }

        private void JukeboxPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            songJacketPinnedBitmap.Dispose();
            playbackFinished = true;

            waveOutEvent.Stop();
            waveOutEvent.Dispose();

            assetsManager.Clear();
        }

        private void SeekTrackBar_Scroll(object sender, EventArgs e)
        {
            songMixer.Position = (long)(songMixer.Length * (float)(seekTrackBar.Value / 100.0f));
            seeked = true;
        }

        private void VolumeTrackbar_Scroll(object sender, EventArgs e)
        {
            waveOutEvent.Volume = volumeTrackbar.Value / 100.0f;
            volumeLabel.Text = (int)Math.Ceiling(waveOutEvent.Volume * 100.0f) + "%";
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

        private void DoLyricsPlayback()
        {
            //LyricsTrigger currentLyricsTrigger = lyricsTriggers[lyricsTriggerIndex];
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
                        lyricsLabel.Text = lyricsTriggers[lyricsTriggerIndex].Lyrics;
                    });

                    if (lyricsTriggerIndex < lyricsTriggers.Count - 1)
                        lyricsTriggerIndex++;
                    else break;

                    //currentLyricsTrigger = lyricsTriggers[lyricsTriggerIndex];
                }

                Thread.Sleep(1);
            }
        }

        private static AwbReader GetAwbFile(GameAsset gameFile)
        {
            string awbPath = UmaDataHelper.GetPath(gameFile);
            return new(File.OpenRead(awbPath));
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

        private void SetupButton_Click(object sender, EventArgs e)
        {
            SetupUnit();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            waveOutEvent.Stop();
            waveOutEvent.Dispose();
            songMixer.Dispose();
            Close();
        }
    }
}
