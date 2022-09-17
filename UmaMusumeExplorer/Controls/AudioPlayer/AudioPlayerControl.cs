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
using UmaMusumeExplorer.Controls.AudioPlayer.Classes;
using UmaMusumeData;
using System.Threading;

namespace UmaMusumeExplorer.Controls.AudioPlayer
{
    public partial class AudioPlayerControl : UserControl
    {
        private readonly object waveOutLock = new();
        private readonly IEnumerable<GameAsset> bgmAssets = AssetTables.AudioAssets;
        private IEnumerable<GameAsset> awbOnly;

        private AwbReader awbReader;
        private UmaWaveStream umaWaveStream;
        private WaveOutEvent waveOut;
        private VolumeSampleProvider volumeSampleProvider;
        private bool initialized = false;
        private int totalFiles;
        private string currentFileName = "";

        public AudioPlayerControl()
        {
            InitializeComponent();

            waveOut = new WaveOutEvent() { DesiredLatency = 100 };
        }

        private void AudioPlayerControl_Load(object sender, EventArgs e)
        {
            audioTypeComboBox.SelectedIndex = 0;

            fileListView.Columns[0].Width = (int)(fileListView.Width * 0.80f);
            fileListView.Columns[1].Width = -2;
        }

        private void AudioTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            char audioType;

            if (audioTypeComboBox.SelectedIndex == 0)
                audioType = 'b';
            else if (audioTypeComboBox.SelectedIndex == 1)
                audioType = 'c';
            else if (audioTypeComboBox.SelectedIndex == 2)
                audioType = 'j';
            else if (audioTypeComboBox.SelectedIndex == 3)
                audioType = 'l';
            else if (audioTypeComboBox.SelectedIndex == 4)
                audioType = 's';
            else
                audioType = 'v';

            awbOnly = bgmAssets.Where((gf) => gf.Name.StartsWith($"sound/{audioType}/") && gf.BaseName.EndsWith(".awb"));
            totalFiles = awbOnly.Count();

            fileListView.Items.Clear();

            loadingProgressBar.Visible = true;
            loadingFileNameLabel.Visible = true;
            audioTypeComboBox.Enabled = false;
            refreshButton.Enabled = false;

            loadingBackgroundWorker.RunWorkerAsync();
        }

        private void LoadingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;

            List<ListViewItem> listViewItems = new();

            backgroundWorker.ReportProgress(0);

            int currentFile = 0;
            foreach (var gameFile in awbOnly)
            {
                if (File.Exists(UmaDataHelper.GetPath(gameFile)))
                {
                    FileStream awbFile = File.OpenRead(UmaDataHelper.GetPath(gameFile));
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
            e.Result = listViewItems.ToArray();
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
            audioTypeComboBox.Enabled = true;
            refreshButton.Enabled = true;

            if (e.Result is not null) fileListView.Items.AddRange(e.Result as ListViewItem[]);

            fileListView.Columns[0].Width = (int)(fileListView.ClientSize.Width * (float)0.80);
            fileListView.Columns[1].Width = -2;
        }

        private void FileListView_ItemActivate(object sender, EventArgs e)
        {
            ListView fileList = sender as ListView;
            GameAsset gameFile = fileList.SelectedItems[0].Tag as GameAsset;

            ChangeBank(gameFile);
        }

        private void TracksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTimer.Enabled = false;

            ComboBox comboBox = sender as ComboBox;

            int waveId = ((TrackComboBoxItem)comboBox.SelectedItem).WaveId;
            awbReader = ((TrackComboBoxItem)comboBox.SelectedItem).AwbReader;

            lock (waveOutLock)
            {
                umaWaveStream = new(awbReader, waveId);

                timeLengthLabel.Text = umaWaveStream.TotalTime.ToString("mm\\:ss");

                InitializeWaveOut(umaWaveStream);
                waveOut.Play();
                initialized = true;
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
            TrackBar trackBar = sender as TrackBar;

            if (trackBar.Capture)
                umaWaveStream.Position = (long)(umaWaveStream.Length * ((float)trackBar.Value / trackBar.Maximum)) - 1;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (initialized)
            {
                try
                {
                    if (waveOut.PlaybackState == PlaybackState.Playing)
                        waveOut.Pause();
                    else
                        waveOut.Play();
                }
                catch (Exception)
                {
                    InitializeWaveOut(umaWaveStream);
                    waveOut.Play();
                }
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
            if (tracksComboBox.SelectedItem is not null)
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
            if (umaWaveStream is not null)
                ControlHelpers.ShowFormDialogCenter(new ConfigureLoopForm(umaWaveStream), this);
        }

        private void AmplifyUpDown_ValueChanged(object sender, EventArgs e)
        {
            volumeSampleProvider.Volume = (float)amplifyUpDown.Value;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            totalFiles = awbOnly.Count();

            fileListView.Items.Clear();

            loadingProgressBar.Visible = true;
            loadingFileNameLabel.Visible = true;
            audioTypeComboBox.Enabled = false;
            refreshButton.Enabled = false;

            loadingBackgroundWorker.RunWorkerAsync();
        }

        private void ChangeBank(GameAsset gameFile)
        {
            lock (waveOutLock)
            {
                waveOut.Stop();
                awbReader?.Dispose();

                string awbPath = UmaDataHelper.GetPath(gameFile);
                awbReader = new(File.OpenRead(awbPath));

                string acbName = gameFile.BaseName[0..^4] + ".acb";
                string acbPath = UmaDataHelper.GetPath(bgmAssets.FirstOrDefault((gf) => gf.BaseName == acbName));
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
        }

        private void InitializeWaveOut(WaveStream waveStream)
        {
            waveOut.Stop();
            volumeSampleProvider = new VolumeSampleProvider(waveStream.ToSampleProvider()) { Volume = (float)amplifyUpDown.Value };
            waveOut.Init(volumeSampleProvider);
        }
    }
}
