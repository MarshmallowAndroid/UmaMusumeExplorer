using CriWareFormats;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UmaMusumeAudio;
using UmaMusumeExplorer.Controls;
using UmaMusumeExplorer.Controls.AudioPlayer;
using UmaMusumeFiles;

namespace PlayerGui.Controls.AudioPlayer
{
    public partial class AudioPlayerControl : UserControl
    {
        private readonly object waveOutLock = new();

        private List<GameAsset> gameAssets;
        private AwbReader awbReader;
        private UmaWaveStream umaWaveStream;
        private WaveOutEvent waveOut;
        private bool initialized = false;
        private int totalFiles;
        private string currentFileName = "";

        //private MixingSampleProvider mix;

        public AudioPlayerControl()
        {
            InitializeComponent();
        }

        private void AudioPlayerControl_Load(object sender, EventArgs e)
        {
            fileListView.Columns[0].Width = (int)(fileListView.Width * (float)0.80);
            fileListView.Columns[1].Width = -2;

            if (!DesignMode) loadingBackgroundWorker.RunWorkerAsync();
        }

        private void LoadingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;

            gameAssets = UmaFileHelper.GetGameAssetDataRows(ga => ga.Name.StartsWith("sound/b/"));
            IEnumerable<GameAsset> awbOnly = gameAssets.Where((gf) => gf.BaseName.EndsWith(".awb"));
            totalFiles = awbOnly.Count();

            List<ListViewItem> listViewItems = new();

            backgroundWorker.ReportProgress(0);

            int currentFile = 0;
            foreach (var gameFile in awbOnly)
            {
                if (File.Exists(UmaFileHelper.GetPath(gameFile)))
                {
                    FileStream awbFile = File.OpenRead(UmaFileHelper.GetPath(gameFile));
                    AwbReader awbReader = new(awbFile);

                    string name = gameFile.BaseName;

                    listViewItems.Add(new ListViewItem(new string[]
                    { name[0..^4], awbReader.Waves.Count.ToString() })
                    { Tag = gameFile });

                    awbFile.Dispose();
                }

                currentFile++;

                currentFileName = gameFile.BaseName;
                backgroundWorker.ReportProgress(currentFile);
            }

            listViewItems.Sort((lvi1, lvi2) => string.Compare(lvi1.Name, lvi2.Name));
            e.Result = listViewItems;
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingProgressBar.Value = (int)((float)e.ProgressPercentage / totalFiles * 100);
            loadingFileNameLabel.Text = currentFileName;
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingProgressBar.Visible = false;
            loadingFileNameLabel.Visible = false;
            fileListView.Items.AddRange(((List<ListViewItem>)e.Result).ToArray());
            fileListView.Columns[0].Width = (int)(fileListView.ClientSize.Width * (float)0.80);
            fileListView.Columns[1].Width = -2;

            waveOut = new WaveOutEvent() { DesiredLatency = 100 };
        }

        private void FileListView_ItemActivate(object sender, EventArgs e)
        {
            ListView fileList = (ListView)sender;
            GameAsset gameFile = (GameAsset)fileList.SelectedItems[0].Tag;

            ChangeBank(gameFile);
        }

        private void ChangeBank(GameAsset gameFile)
        {
            waveOut.Stop();
            awbReader?.Dispose();

            string awbPath = UmaFileHelper.GetPath(gameFile);
            awbReader = new(File.OpenRead(awbPath));

            string acbName = gameFile.BaseName[0..^4] + ".acb";
            string acbPath = UmaFileHelper.GetPath(gameAssets.FirstOrDefault((gf) => gf.BaseName == acbName));
            FileStream acbFile = File.OpenRead(acbPath);
            AcbReader acbReader = new(acbFile);

            tracksComboBox.Items.Clear();

            foreach (var wave in awbReader.Waves)
            {
                string waveNames = acbReader.GetWaveName(wave.WaveId, 0, false);

                tracksComboBox.Items.Add(new TrackComboBoxItem()
                {
                    TrackName = waveNames,
                    WaveId = wave.WaveId,
                    AwbReader = awbReader
                });
            }

            acbFile.Dispose();

            tracksComboBox.SelectedIndex = 0;
        }

        private void TracksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTimer.Enabled = false;

            ComboBox comboBox = (ComboBox)sender;

            int waveID = ((TrackComboBoxItem)comboBox.SelectedItem).WaveId;
            awbReader = ((TrackComboBoxItem)comboBox.SelectedItem).AwbReader;

            lock (waveOutLock)
            {
                umaWaveStream = new(awbReader, waveID);

                timeLengthLabel.Text = umaWaveStream.TotalTime.ToString("mm\\:ss");

                waveOut.Stop();
                waveOut.Init(new VolumeSampleProvider(umaWaveStream.ToSampleProvider()) { Volume = 4.0f });
                initialized = true;
                waveOut.Play();
            }

            updateTimer.Enabled = true;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!seekTrackBar.Capture)
                seekTrackBar.Value = (int)((float)umaWaveStream.Position / umaWaveStream.Length * 100);

            timeElapsedLabel.Text = umaWaveStream.CurrentTime.ToString("mm\\:ss");
        }

        private void SeekTrackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;

            if (trackBar.Capture)
                umaWaveStream.Position = (long)(umaWaveStream.Length * ((float)trackBar.Value / trackBar.Maximum)) - 1;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (initialized)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                    waveOut.Pause();
                else
                    waveOut.Play();
            }
        }

        private void PrevTrackButton_Click(object sender, EventArgs e)
        {
            if (tracksComboBox.SelectedIndex > 0)
                tracksComboBox.SelectedIndex--;
            else tracksComboBox.SelectedIndex = tracksComboBox.Items.Count - 1;
        }

        private void NextTrackButton_Click(object sender, EventArgs e)
        {
            if (tracksComboBox.SelectedIndex + 1 < tracksComboBox.Items.Count)
                tracksComboBox.SelectedIndex++;
            else tracksComboBox.SelectedIndex = 0;
        }

        private void PrevBankButton_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedIndices.Count > 0)
            {
                int selectedItemIndex = fileListView.SelectedIndices[0];
                fileListView.Items[selectedItemIndex].Selected = false;

                if (selectedItemIndex > 0)
                    selectedItemIndex--;
                else selectedItemIndex = fileListView.Items.Count - 1;

                ListViewItem newItem = fileListView.Items[selectedItemIndex];
                newItem.Selected = true;
                newItem.EnsureVisible();

                ChangeBank((GameAsset)newItem.Tag);
            }
        }

        private void NextBankButton_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedIndices.Count > 0)
            {
                int selectedItemIndex = fileListView.SelectedIndices[0];
                fileListView.Items[selectedItemIndex].Selected = false;

                if (selectedItemIndex + 1 < fileListView.Items.Count)
                    selectedItemIndex++;
                else selectedItemIndex = 0;

                ListViewItem newItem = fileListView.Items[selectedItemIndex];
                newItem.Selected = true;
                newItem.EnsureVisible();

                ChangeBank((GameAsset)newItem.Tag);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (tracksComboBox.SelectedItem != null)
            {
                string outputFileName = ((TrackComboBoxItem)tracksComboBox.SelectedItem).TrackName;

                SaveFileDialog save = new()
                {
                    DefaultExt = "wav",
                    FileName = outputFileName,
                    Filter = "16-bit PCM WAV files (*.wav) | *.wav"
                };

                DialogResult result = save.ShowDialog();

                if (result == DialogResult.OK)
                {
                    waveOut.Pause();
                    umaWaveStream.Loop = false;

                    long restore = umaWaveStream.Position;
                    umaWaveStream.Position = 0;

                    WaveFileWriter.CreateWaveFile16(save.FileName,
                        new VolumeSampleProvider(umaWaveStream.ToSampleProvider())
                        {
                            Volume = 4.0f
                        });

                    umaWaveStream.Position = restore;
                    umaWaveStream.Loop = true;
                    waveOut.Play();
                }
            }
        }

        private void ConfigureLoopButton_Click(object sender, EventArgs e)
        {
            if (umaWaveStream != null)
                ControlHelpers.ShowFormDialogCenter(new ConfigureLoopForm(umaWaveStream), this);
        }
    }
}
