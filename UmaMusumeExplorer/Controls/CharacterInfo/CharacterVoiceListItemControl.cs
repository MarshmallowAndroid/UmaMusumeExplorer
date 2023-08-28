using CriWareLibrary;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmaMusumeAudio;
using UmaMusumeData;
using UmaMusumeExplorer.Game;

namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    public partial class CharacterVoiceListItemControl : UserControl
    {
        private WaveStream voiceWaveStream;
        private Timer animationTimer;
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
                GameAsset acbAsset = AssetTables.AudioAssets.FirstOrDefault(a => a.BaseName == systemText.CueSheet + ".acb");
                GameAsset awbAsset = AssetTables.AudioAssets.FirstOrDefault(a => a.BaseName == systemText.CueSheet + ".awb");

                if (acbAsset is null && awbAsset is null) return;

                string acbPath = UmaDataHelper.GetPath(acbAsset);
                string awbPath = UmaDataHelper.GetPath(awbAsset);

                if (!File.Exists(awbPath)) return;

                waveOut.PlaybackStopped -= PlaybackStopped;

                if (waveOut.PlaybackState == PlaybackState.Playing)
                    waveOut.Stop();

                voiceWaveStream?.Dispose();

                AcbReader acb = new(File.OpenRead(acbPath));
                AwbReader awb = new(File.OpenRead(awbPath));

                voiceWaveStream = new UmaWaveStream(awb, acb.GetWaveIdFromCueId(systemText.CueId));

                animationTimer?.Stop();
                animationTimer?.Dispose();

                animationTimer = new();
                animationTimer.Enabled = true;
                animationTimer.Interval = 50;
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

        public CharacterSystemText CharacterSystemText { get; }

        public WaveStream GetWaveStream()
        {
            GameAsset acbAsset = AssetTables.AudioAssets.FirstOrDefault(a => a.BaseName == CharacterSystemText.CueSheet + ".acb");
            GameAsset awbAsset = AssetTables.AudioAssets.FirstOrDefault(a => a.BaseName == CharacterSystemText.CueSheet + ".awb");

            if (acbAsset is null && awbAsset is null) return null;

            string acbPath = UmaDataHelper.GetPath(acbAsset);
            string awbPath = UmaDataHelper.GetPath(awbAsset);

            if (!File.Exists(awbPath)) return null;

            AcbReader acb = new(File.OpenRead(acbPath));
            AwbReader awb = new(File.OpenRead(awbPath));

            return new UmaWaveStream(awb, acb.GetWaveIdFromCueId(CharacterSystemText.CueId));
        }

        public bool Checked => checkBox.Checked;

        private void ClickHit(object sender, EventArgs e)
        {
            if (processingClick) return;

            processingClick = true;

            try
            {
                MouseEventArgs mouseEventArgs = e as MouseEventArgs;
                if (mouseEventArgs.Button != MouseButtons.Left) return;

                checkBox.Checked = !checkBox.Checked;
            }
            finally
            {
                processingClick = false;
            }
        }

        private void VoiceLineTextLabel_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(voiceLineTextLabel.Text);
        }

        private void PlaybackStopped(object sender, EventArgs e)
        {
            voiceLineTextLabel.Progress = 0;
            animationTimer.Stop();
            animationTimer.Dispose();
        }
    }
}
