using CriWareLibrary;
using NAudio.Wave;
using UmaMusumeAudio;
using UmaMusumeData;
using UmaMusumeExplorer.Game;
using Timer = System.Windows.Forms.Timer;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class CharacterVoiceListItemControl : UserControl
    {
        private WaveStream? voiceWaveStream;
        private Timer? animationTimer;
        private bool processingClick = false;

        public CharacterVoiceListItemControl()
        {
            InitializeComponent();

            DoubleBuffered = true;

            idLabel.Click += ClickHit;
            idLabel.DoubleClick += ClickHit;
        }

        public CharacterVoiceListItemControl(CharacterSystemText systemText, IWavePlayer waveOut) : this()
        {
            CharacterSystemText = systemText;

            idLabel.Text = systemText.VoiceId.ToString();
            voiceLineTextLabel.Text = systemText.Text;
            playButton.Click += (s, e) =>
            {
                waveOut.PlaybackStopped -= PlaybackStopped;

                if (waveOut.PlaybackState == PlaybackState.Playing)
                    waveOut.Stop();

                voiceWaveStream?.Dispose();
                voiceWaveStream = GetWaveStream();

                voiceLineTextLabel.Progress = 0;
                animationTimer?.Stop();
                animationTimer?.Dispose();

                animationTimer = new()
                {
                    Enabled = true,
                    Interval = 50
                };
                animationTimer.Tick += (s, e) =>
                {
                    if (voiceWaveStream is not null)
                        voiceLineTextLabel.Progress = (float)voiceWaveStream.Position / voiceWaveStream.Length;
                };
                animationTimer.Start();

                waveOut.PlaybackStopped += PlaybackStopped;

                waveOut.Init(voiceWaveStream);
                waveOut.Play();
            };
        }

        public CharacterSystemText? CharacterSystemText { get; }

        public bool Checked => checkBox.Checked;

        public WaveStream? GetWaveStream()
        {
            if (CharacterSystemText is null) return null;

            GameAsset? acbAsset = AssetTables.AudioAssets.FirstOrDefault(a => a.BaseName == CharacterSystemText.CueSheet + ".acb");
            GameAsset? awbAsset = AssetTables.AudioAssets.FirstOrDefault(a => a.BaseName == CharacterSystemText.CueSheet + ".awb");

            if (acbAsset is null && awbAsset is null) return null;

            string acbPath = UmaDataHelper.GetPath(acbAsset);
            string awbPath = UmaDataHelper.GetPath(awbAsset);

            if (!File.Exists(awbPath)) return null;

            AcbReader acb = new(File.OpenRead(acbPath));
            AwbReader awb = new(File.OpenRead(awbPath));

            return new UmaWaveStream(awb, acb.GetWaveIdFromCueId(CharacterSystemText.CueId));
        }

        private void ClickHit(object? sender, EventArgs e)
        {
            if (processingClick) return;

            processingClick = true;

            try
            {
                if (e is not MouseEventArgs mouseEventArgs) return;
                if (mouseEventArgs.Button != MouseButtons.Left) return;

                checkBox.Checked = !checkBox.Checked;
            }
            finally
            {
                processingClick = false;
            }
        }

        private void VoiceLineTextLabel_DoubleClick(object? sender, EventArgs e)
        {
            Clipboard.SetText(voiceLineTextLabel.Text);
        }

        private void PlaybackStopped(object? sender, EventArgs e)
        {
            voiceLineTextLabel.Progress = 0;
            animationTimer?.Stop();
        }
    }
}
