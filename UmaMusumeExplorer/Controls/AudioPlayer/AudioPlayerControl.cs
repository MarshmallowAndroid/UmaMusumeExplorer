using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.ComponentModel;
using System.Data;
using UmaMusumeAudio;
using UmaMusumeData;
using UmaMusumeExplorer.Controls.AudioPlayer.Classes;
using UmaMusumeExplorer.Game;
using Color = System.Drawing.Color;

namespace UmaMusumeExplorer.Controls.AudioPlayer
{
    partial class AudioPlayerControl : UserControl
    {
        private readonly IWavePlayer waveOut;
        private readonly object waveOutLock = new();

        private readonly IEnumerable<GameAsset> audioAssets = AssetTables.AudioAssets;
        private char audioType;
        private IEnumerable<GameAsset>? awbOnly;

        private IEnumerable<ListViewItem>? defaultItems;
        private IEnumerable<ListViewItem>? targetItems;
        private Func<ListViewItem, bool>? filterPredicate = null;

        private int totalFiles;

        private UmaWaveStream? umaWaveStream;
        private VolumeSampleProvider? volumeSampleProvider;

        public AudioPlayerControl()
        {
            InitializeComponent();

            waveOut = new WaveOutEvent() { DesiredLatency = 100 };

            if (Application.UseVisualStyles)
                seekTrackBar.BackColor = Color.FromArgb(255, 249, 249, 249);
        }

        private void AudioPlayerControl_Load(object sender, EventArgs e)
        {
            if (!audioAssets.Any()) return;

            audioTypeComboBox.SelectedIndex = 0;

            fileListView.Columns[0].Width = (int)(fileListView.Width * 0.80F);
            fileListView.Columns[1].Width = -2;
        }

        private void AudioTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            if (audioAssets is not null)
                awbOnly = audioAssets.Where((gf) => gf.Name.StartsWith($"sound/{audioType}/") && gf.BaseName.EndsWith(".awb"));

            if (awbOnly is null) return;

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
            if (sender is not BackgroundWorker backgroundWorker) return;
            if (awbOnly is null) return;

            List<ListViewItem> listViewItems = new();

            backgroundWorker.ReportProgress(0);

            int currentFile = 0;
            foreach (var gameFile in awbOnly)
            {
                string baseName = gameFile.BaseName[0..^4];
                string acbName = baseName + ".acb";
                string acbPath = UmaDataHelper.GetPath(AssetTables.AudioAssets.FirstOrDefault((gf) => gf.BaseName == acbName));
                string awbPath = UmaDataHelper.GetPath(gameFile);

                if (File.Exists(awbPath) && File.Exists(acbPath))
                {
                    AtomAudioSource audioSource = new(baseName, acbPath, awbPath);

                    string name = gameFile.BaseName;

                    listViewItems.Add(new ListViewItem(new string[]
                    { baseName, audioSource.TrackCount.ToString() })
                    { Tag = audioSource });
                }

                currentFile++;

                backgroundWorker.ReportProgress(currentFile, gameFile.BaseName);
            }

            listViewItems.Sort((lvi1, lvi2) => string.Compare(lvi1.Name, lvi2.Name));
            e.Result = listViewItems;
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingProgressBar.Value = (int)((float)e.ProgressPercentage / totalFiles * 100);
            loadingFileNameLabel.Text = e.UserState as string;
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingProgressBar.Visible = false;
            loadingFileNameLabel.Visible = false;
            audioTypeComboBox.Enabled = true;
            refreshButton.Enabled = true;

            if (e.Result is not null)
            {
                defaultItems = e.Result as List<ListViewItem>;
                Filter();
                fileListView.Items.AddRange(targetItems?.ToArray());
            }

            fileListView.Columns[0].Width = (int)(fileListView.ClientSize.Width * (float)0.80F);
            fileListView.Columns[1].Width = -2;
        }

        private void FileListView_ItemActivate(object sender, EventArgs e)
        {
            if (sender is not ListView fileList) return;
            AudioSource? audioSource = fileList.SelectedItems[0].Tag as AudioSource;
            ChangeAudioSource(audioSource);
        }

        private void FileListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;

                foreach (ListViewItem item in fileListView.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private void TracksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTimer.Enabled = false;

            if (sender is not ComboBox comboBox) return;
            IAudioTrack audioTrack = ((TrackComboBoxItem)comboBox.SelectedItem).Track;

            lock (waveOutLock)
            {
                waveOut?.Stop();

                umaWaveStream?.Dispose();
                umaWaveStream = (UmaWaveStream)audioTrack.WaveStream;

                timeLengthLabel.Text = umaWaveStream.TotalTime.ToString("mm\\:ss");

                InitializeWaveOut(umaWaveStream);
                waveOut?.Play();
            }

            updateTimer.Enabled = true;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (umaWaveStream is null) return;
            seekTrackBar.Value = (int)((float)umaWaveStream.Position / umaWaveStream.Length * 100);
            timeElapsedLabel.Text = umaWaveStream.CurrentTime.ToString("mm\\:ss");
        }

        private void SeekTrackBar_Scroll(object sender, EventArgs e)
        {
            if (sender is not TrackBar trackBar) return;
            if (umaWaveStream is null) return;
            umaWaveStream.Position = (long)(umaWaveStream.Length * ((float)trackBar.Value / trackBar.Maximum)) - 1;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (umaWaveStream is null) return;

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

                ChangeAudioSource((AudioSource)newItem.Tag);
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

                ChangeAudioSource((AudioSource)newItem.Tag);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            IAudioTrack audioTrack = ((TrackComboBoxItem)tracksComboBox.SelectedItem).Track;
            ExportTrack(audioTrack);
        }

        private void ConfigureLoopButton_Click(object sender, EventArgs e)
        {
            if (umaWaveStream is not null)
                ControlHelpers.ShowFormDialogCenter(new ConfigureLoopForm(umaWaveStream), this);
        }

        private void AmplifyUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (volumeSampleProvider is not null)
                volumeSampleProvider.Volume = (float)amplifyUpDown.Value;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            fileListView.Items.Clear();

            loadingProgressBar.Visible = true;
            loadingFileNameLabel.Visible = true;
            audioTypeComboBox.Enabled = false;
            refreshButton.Enabled = false;

            loadingBackgroundWorker.RunWorkerAsync();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (filterPredicate is null)
            {
                filterPredicate = ga => ga.Text.Contains(searchBox.Text);
                filterButton.Text = "Reset";
            }
            else
            {
                filterPredicate = null;
                filterButton.Text = "Filter";
            }

            Filter();

            fileListView.Items.Clear();
            fileListView.Items.AddRange(targetItems?.ToArray());
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AudioSource> audioSources = new();
            foreach (ListViewItem item in fileListView.SelectedItems)
            {
                audioSources.Add((AudioSource)item.Tag);
            }
            ExportBank(audioSources.ToArray());
        }

        private void Filter()
        {
            if (filterPredicate is not null)
            {
                targetItems = defaultItems?.Where(filterPredicate);
            }
            else
            {
                targetItems = defaultItems;
            }
        }

        private void ChangeAudioSource(AudioSource? audioSource)
        {
            if (audioSource is null) return;

            tracksComboBox.Items.Clear();
            for (int i = 0; i < audioSource.Tracks.Length; i++)
            {
                IAudioTrack track = audioSource.Tracks[i];
                tracksComboBox.Items.Add(
                    new TrackComboBoxItem(track.Name, i, track));
            }
            tracksComboBox.SelectedIndex = 0;
        }

        private void InitializeWaveOut(WaveStream waveStream)
        {
            waveOut.Stop();
            volumeSampleProvider = new VolumeSampleProvider(waveStream.ToSampleProvider()) { Volume = (float)amplifyUpDown.Value };
            waveOut.Init(volumeSampleProvider);
        }

        private void ExportBank(AudioSource[] audioSources)
        {
            FolderBrowserDialog folderBrowser = new();

            if (audioSources.Length == 1)
            {
                AudioSource single = audioSources[0];
                if (single.Tracks.Length == 1)
                    ExportTrack(single.Tracks[0]);
                else
                {
                    DialogResult result = folderBrowser.ShowDialog();
                    if (result != DialogResult.OK) return;

                    string selected = folderBrowser.SelectedPath;
                    string directory = Path.Combine(selected, single.Name);

                    Directory.CreateDirectory(directory);

                    Task.Run(() =>
                    {
                        int currentTrack = 1;
                        foreach (var track in single.Tracks)
                        {
                            UmaWaveStream copy = (UmaWaveStream)track.WaveStream;
                            copy.Loop = false;
                            WaveFileWriter.CreateWaveFile16(Path.Combine(directory, track.Name + $"_{currentTrack++:d2}.wav"), copy.ToSampleProvider());

                            copy.Dispose();
                            Invoke(() => exportButton.Enabled = true);
                        }

                        MessageBox.Show("Export complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                }
            }
            else
            {
                DialogResult result = folderBrowser.ShowDialog();
                if (result != DialogResult.OK) return;

                string directory = folderBrowser.SelectedPath;

                ControlHelpers.ShowFormCenter(new MultipleExportDialog(audioSources, directory), this);
            }
        }

        private void ExportTrack(IAudioTrack audioTrack)
        {
            SaveFileDialog save = new()
            {
                FileName = audioTrack.Name,
                Filter = "16-bit PCM WAV|*.wav"
            };

            DialogResult result = save.ShowDialog();
            if (result != DialogResult.OK) return;

            exportButton.Enabled = false;
            Task.Run(() =>
            {
                UmaWaveStream copy = (UmaWaveStream)audioTrack.WaveStream;
                copy.Loop = false;

                WaveFileWriter.CreateWaveFile16(save.FileName,
                    new VolumeSampleProvider(copy.ToSampleProvider())
                    {
                        Volume = (float)amplifyUpDown.Value
                    });

                MessageBox.Show("Export complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                copy.Dispose();

                Invoke(() => exportButton.Enabled = true);
            });
        }
    }
}
