using CriWareFormats;
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
        private readonly Timer animationTimer = new();

        private WaveStream voiceWaveStream;

        public CharacterVoiceListItemControl()
        {
            InitializeComponent();

            DoubleBuffered = true;

            idLabel.MouseClick += ClickHit;
            voiceLineTextLabel.MouseClick += ClickHit;

            animationTimer.Enabled = true;
            animationTimer.Interval = 50;
            animationTimer.Tick += (s, e) =>
            {
                if (voiceWaveStream is not null)
                    voiceLineTextLabel.Progress = (float)voiceWaveStream.Position / voiceWaveStream.Length;
            };
        }

        public CharacterVoiceListItemControl(CharacterSystemText systemText, IWavePlayer waveOut) : this()
        {
            CharacterSystemText = systemText;

            idLabel.Text = $"ID {systemText.VoiceId}";
            voiceLineTextLabel.Text = systemText.Text;
            playButton.Click += (s, e) =>
            {
                GameAsset acbAsset = AssetTables.AudioAssets.FirstOrDefault(a => a.BaseName == systemText.CueSheet + ".acb");
                GameAsset awbAsset = AssetTables.AudioAssets.FirstOrDefault(a => a.BaseName == systemText.CueSheet + ".awb");

                if (acbAsset is null && awbAsset is null) return;

                string acbPath = UmaDataHelper.GetPath(acbAsset);
                string awbPath = UmaDataHelper.GetPath(awbAsset);

                if (!File.Exists(awbPath)) return;

                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.PlaybackStopped -= PlaybackStopped;
                    waveOut.Stop();
                }

                AcbReader acb = new(File.OpenRead(acbPath));
                AwbReader awb = new(File.OpenRead(awbPath));

                voiceWaveStream = new UmaWaveStream(awb, acb.GetWaveIdFromCueId(systemText.CueId));

                animationTimer.Start();

                waveOut.Init(voiceWaveStream);
                waveOut.Play();

                waveOut.PlaybackStopped += PlaybackStopped;
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
            checkBox.Checked = !checkBox.Checked;
        }

        private void PlaybackStopped(object sender, EventArgs e)
        {
            animationTimer.Stop();
            voiceLineTextLabel.Progress = 0;
        }
    }
}
