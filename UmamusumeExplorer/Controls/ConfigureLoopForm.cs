using UmamusumeAudio;

namespace UmamusumeExplorer.Controls
{
    partial class ConfigureLoopForm : Form
    {
        private readonly UmaWaveStream hcaWaveStream;

        public ConfigureLoopForm(UmaWaveStream waveStream)
        {
            InitializeComponent();

            hcaWaveStream = waveStream;
        }

        private void LoopModifyForm_Load(object sender, EventArgs e)
        {
            LoadValues();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            hcaWaveStream.Loop = loopEnabledCheckBox.Checked;
            hcaWaveStream.LoopStartSample = (long)startSampleNumericUpDown.Value;
            hcaWaveStream.LoopEndSample = (long)endSampleNumericUpDown.Value;

            Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            hcaWaveStream.ResetLoop();
            LoadValues();
        }

        private void LoadValues()
        {
            loopEnabledCheckBox.Checked = hcaWaveStream.Loop;
            startSampleNumericUpDown.Value = hcaWaveStream.LoopStartSample;
            endSampleNumericUpDown.Value = hcaWaveStream.LoopEndSample;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
