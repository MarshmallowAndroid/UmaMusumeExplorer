using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeAudio;
using UmaMusumeExplorer.Controls.AudioPlayer.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace UmaMusumeExplorer.Controls.AudioPlayer
{
    public partial class MultipleExportDialog : Form
    {
        private readonly AudioSource[] sources;
        private readonly string outputPath;

        public MultipleExportDialog(AudioSource[] audioSources, string outputDirectory)
        {
            InitializeComponent();

            sources = audioSources;
            outputPath = outputDirectory;

            exportBackgroundWorker.RunWorkerAsync();
        }

        private void ExportBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int currentFile = 1;

            foreach (var audioSource in sources)
            {
                if (exportBackgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                State state;
                state.Name = audioSource.Name;
                state.CurrentFile = currentFile;

                exportBackgroundWorker.ReportProgress((int)(((float)currentFile / sources.Length) * 100), state);

                if (audioSource.Tracks.Length > 1)
                {
                    string directory = Path.Combine(outputPath, audioSource.Name);
                    Directory.CreateDirectory(directory);

                    foreach (var track in audioSource.Tracks)
                    {
                        UmaWaveStream waveStream = (UmaWaveStream)track.WaveStream;
                        waveStream.Loop = false;
                        WaveFileWriter.CreateWaveFile16(Path.Combine(directory, track.Name + ".wav"), waveStream.ToSampleProvider());
                    }
                }
                else
                {
                    IAudioTrack audioTrack = audioSource.Tracks[0];
                    UmaWaveStream waveStream = (UmaWaveStream)audioTrack.WaveStream;
                    waveStream.Loop = false;
                    WaveFileWriter.CreateWaveFile16(Path.Combine(outputPath, audioTrack.Name + ".wav"), waveStream.ToSampleProvider());
                }

                currentFile++;
            }
        }

        private void ExportBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;

            State state = (State)e.UserState;

            currentFileLabel.Text = "Exporing " + state.Name;
            progressLabel.Text = $"{state.CurrentFile} of {sources.Length}";
        }

        private void ExportBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("Export cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Export complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            exportBackgroundWorker.CancelAsync();
        }

        struct State
        {
            public string Name;
            public int CurrentFile;
        }
    }
}
