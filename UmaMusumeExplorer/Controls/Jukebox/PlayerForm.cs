using AssetStudio;
using CriWareLibrary;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeAudio;
using UmaMusumeData;
using UmaMusumeData.Tables;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.Jukebox
{
    partial class PlayerForm : Form
    {
        private readonly JukeboxMusicData jukeboxMusicData;
        private readonly SongLength songLength;
        private readonly int musicId;

        private readonly AssetsManager assetsManager = new();
        private readonly PinnedBitmap songJacketPinnedBitmap;

        private UmaWaveStream musicWaveStream;
        private readonly IWavePlayer waveOut = new WaveOutEvent() { DesiredLatency = 250 };

        public PlayerForm(JukeboxMusicData jukeboxMusic, SongLength length)
        {
            InitializeComponent();

            jukeboxMusicData = jukeboxMusic;
            songLength = length;
            musicId = jukeboxMusic.MusicId;

            songJacketPinnedBitmap = UnityAssets.GetJacket(musicId, 'l');
            songJacketPictureBox.BackgroundImage = songJacketPinnedBitmap.Bitmap;
            songTitleLabel.Text = AssetTables.GetText(TextCategory.MasterLiveTitle, musicId);
            songInfoLabel.Text = AssetTables.GetText(TextCategory.MasterLiveAuthor, musicId).Replace("\\n", "\n");
        }

        private void LiveMusicPlayerForm_Load(object sender, EventArgs e)
        {
            if (!SetupMusic())
            {
                Close();
                return;
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
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
            currentTimeLabel.Text = $"{musicWaveStream.CurrentTime:m\\:ss}";
            seekTrackBar.Value = (int)(musicWaveStream.CurrentTime / musicWaveStream.TotalTime * 100.0F);
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            songJacketPinnedBitmap.Dispose();

            waveOut.Stop();
            waveOut.Dispose();

            assetsManager.Clear();
        }

        private void SeekTrackBar_Scroll(object sender, EventArgs e)
        {
            musicWaveStream.Position = (long)(musicWaveStream.Length * (float)(seekTrackBar.Value / 100.0F));
        }

        private void VolumeTrackbar_Scroll(object sender, EventArgs e)
        {
            waveOut.Volume = volumeTrackbar.Value / 100.0F;
            volumeLabel.Text = (int)Math.Ceiling(waveOut.Volume * 100.0F) + "%";
        }

        private void SetupButton_Click(object sender, EventArgs e)
        {
            SetupMusic();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            waveOut.Stop();
            waveOut.Dispose();
            musicWaveStream.Dispose();
            Close();
        }

        private bool SetupMusic()
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
            IEnumerable<GameAsset> audioAssets = UmaDataHelper.GetGameAssetDataRows(
                ga => ga.Name.ToLower().Contains(cueSheetName.ToLower() + ".awb"));

            // Get BGM without sound effects
            AwbReader okeAwb = GetAwbFile(audioAssets.First());

            if (okeAwb is null) return false;

            // Initialize song mixer on first playback
            if (musicWaveStream is null)
            {
                musicWaveStream = new(okeAwb, 0);
                waveOut.Init(new VolumeSampleProvider(musicWaveStream.ToSampleProvider()) { Volume = 4.0F });
                waveOut.Play();

                updateTimer.Enabled = true;
            }

            // Update the total time and volume track bars
            totalTimeLabel.Text = $"{musicWaveStream.TotalTime:m\\:ss}";
            int volume = (int)Math.Ceiling(waveOut.Volume * 100.0F);
            volumeTrackbar.Value = volume;
            volumeLabel.Text = volume + "%";

            // Unit setup success
            return true;
        }

        private static AwbReader GetAwbFile(GameAsset gameFile)
        {
            string awbPath = UmaDataHelper.GetPath(gameFile);

            if (!File.Exists(awbPath))
            {
                MessageBox.Show(
                    "Audio asset not found.\n\nPlease play the relevant song version on the jukebox in the game to download the asset.",
                    "Asset not found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }

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
    }
}
