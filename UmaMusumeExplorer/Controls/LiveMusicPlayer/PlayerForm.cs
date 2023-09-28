﻿using NAudio.Wave;
using System.Text;
using UmaMusumeData;
using UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes;
using UmaMusumeExplorer.Game;
using Color = System.Drawing.Color;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer
{
    partial class PlayerForm : Form
    {
        private readonly LiveManager liveManager;
        private readonly int musicId;
        private readonly string songTitle;

        private readonly PinnedBitmap songJacketPinnedBitmap;

        private List<LyricsTrigger> lyricsTriggers = new();

        private SongMixer songMixer;
        private readonly IWavePlayer waveOut = new WaveOutEvent() { DesiredLatency = 250 };

        private readonly Thread lyricsThread;
        private readonly Thread voicesThread;
        private int lyricsTriggerIndex = 0;
        private bool seeked = false;
        private bool playbackFinished = false;

        private string[] currentSingers;
        private bool[] singersEnabled;

        private readonly FormAnimator animator;
        private bool expanded = false;

        public PlayerForm(LiveManager live)
        {
            InitializeComponent();

            liveManager = live;
            musicId = live.MusicId;
            songTitle = AssetTables.GetText(TextCategory.MasterLiveTitle, musicId);

            songJacketPinnedBitmap = UnityAssets.GetJacket(musicId, 'l');
            songJacketPictureBox.BackgroundImage = songJacketPinnedBitmap.Bitmap;
            songTitleLabel.Text = songTitle;
            songInfoLabel.Text = AssetTables.GetText(TextCategory.MasterLiveAuthor, musicId).Replace("\\n", "\n");

            lyricsThread = new(DoLyricsPlayback);
            voicesThread = new(DoVoiceUpdate);

            Icon = Icon.FromHandle(songJacketPinnedBitmap.Bitmap.GetHicon());

            animator = new(this, 470, 730);

            // collapsed: 470
            // expanded: 730

            Height = 470;
        }

        private void LiveMusicPlayerForm_Load(object sender, EventArgs e)
        {
            songMixer = liveManager.SongMixer;
            lyricsTriggers = liveManager.LyricsTriggers;

            waveOut.Init(songMixer);
            waveOut.Play();

            lyricsThread.Start();
            voicesThread.Start();
            updateTimer.Enabled = true;

            singersEnabled = new bool[liveManager.CharacterPositions.Length];

            // Update the total time and volume track bars
            totalTimeLabel.Text = $"{songMixer.TotalTime:m\\:ss}";
            int volume = (int)Math.Ceiling(waveOut.Volume * 100.0F);
            volumeTrackbar.Value = volume;
            volumeLabel.Text = volume + "%";

            AddCharacters();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (lyricsThread.ThreadState.HasFlag(ThreadState.Unstarted))
                lyricsThread.Start();

            if (voicesThread.ThreadState.HasFlag(ThreadState.Unstarted))
                voicesThread.Start();

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
            currentTimeLabel.Text = $"{songMixer.CurrentTime:m\\:ss}";
            seekTrackBar.Value = (int)(songMixer.CurrentTime / songMixer.TotalTime * 100.0F);
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            songJacketPinnedBitmap.Dispose();
            playbackFinished = true;

            waveOut.Stop();
            waveOut.Dispose();
        }

        private void SeekTrackBar_Scroll(object sender, EventArgs e)
        {
            songMixer.Position = (long)(songMixer.Length * (float)(seekTrackBar.Value / 100.0F));
            seeked = true;
        }

        private void VolumeTrackbar_Scroll(object sender, EventArgs e)
        {
            waveOut.Volume = volumeTrackbar.Value / 100.0F;
            volumeLabel.Text = (int)Math.Ceiling(waveOut.Volume * 100.0F) + "%";
        }

        private void SetupButton_Click(object sender, EventArgs e)
        {
            if (!liveManager.Setup(this)) return;

            AddCharacters();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            waveOut.Stop();
            waveOut.Dispose();
            songMixer.Dispose();
            Close();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            StringBuilder fileNameString = new();
            fileNameString.Append(songTitle + " (");
            for (int i = 0; i < currentSingers.Length; i++)
            {
                if (!songMixer.CharaTracks[i].Enabled) continue;
                if (i > 0) fileNameString.Append('・');
                fileNameString.Append(currentSingers[i]);
            }
            fileNameString.Append(").wav");

            SaveFileDialog saveFileDialog = new()
            {
                FileName = fileNameString.ToString(),
                Filter = "16-bit PCM WAV|*.wav"
            };

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PlaybackState playbackState = waveOut.PlaybackState;
                waveOut.Pause();

                Task.Run(() =>
                {
                    long restorePosition = songMixer.Position;
                    string restoreInfo = songInfoLabel.Text;

                    songMixer.Position = 0;
                    lyricsTriggerIndex = 0;
                    Invoke(() =>
                    {
                        songInfoLabel.Text = "Exporting...";
                        setupButton.Enabled = false;
                        playButton.Enabled = false;
                        stopButton.Enabled = false;
                        updateTimer.Enabled = true;
                    });

                    WaveFileWriter.CreateWaveFile16(saveFileDialog.FileName, songMixer);

                    songMixer.Position = restorePosition;
                    lyricsTriggerIndex = 0;

                    if (playbackState == PlaybackState.Playing)
                        waveOut.Play();

                    Invoke(() =>
                    {
                        songInfoLabel.Text = restoreInfo;
                        setupButton.Enabled = true;
                        playButton.Enabled = true;
                        stopButton.Enabled = true;
                        updateTimer.Enabled = waveOut.PlaybackState == PlaybackState.Playing;
                    });
                });
            }
        }

        private void MuteBgmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            songMixer.MuteBgm = muteBgmCheckBox.Checked;
        }

        private void CustomVoiceControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            songMixer.CustomMode = customVoiceControlCheckBox.Checked;

            foreach (var control in charaContainerPanel.Controls)
            {
                if (control is CharacterPositionControl chara)
                {
                    CharaTrack track = songMixer.CharaTracks[chara.Position];

                    if (customVoiceControlCheckBox.Checked)
                    {
                        track.Enabled = singersEnabled[chara.Position];
                    }
                    else
                    {
                        track.Enabled = true;
                    }

                    chara.BackColor = track.Enabled ? Color.FromKnownColor(KnownColor.Control) : Color.FromKnownColor(KnownColor.ControlDark);
                }
            }
        }

        private void ExpandButton_Click(object sender, EventArgs e)
        {
            if (!expanded)
                expanded = animator.Expand();
            else
                expanded = !animator.Collapse();
        }

        private void AddCharacters()
        {
            currentSingers = new string[liveManager.CharacterPositions.Length];

            // Add characters position controls to voice control panel
            charaContainerPanel.Controls.Clear();
            foreach (var characterPosition in liveManager.CharacterPositions)
            {
                charaContainerPanel.Controls.Add(
                    new CharacterPositionControl(characterPosition.Position, CharacterClick)
                    {
                        CharacterId = characterPosition.CharacterId,
                        FontSize = 12F,
                        Height = 140,
                        Position = characterPosition.Position,
                        Width = 70
                    });

                currentSingers[characterPosition.Position] = AssetTables.GetText(TextCategory.MasterCharaName, characterPosition.CharacterId);
            }
        }

        private void CharacterClick(object sender, EventArgs e)
        {
            if (customVoiceControlCheckBox.Checked)
            {
                CharacterPositionControl character = (sender as Control).Parent as CharacterPositionControl;
                CharaTrack track = songMixer.CharaTracks[character.Position];
                track.Enabled = !track.Enabled;
                singersEnabled[character.Position] = track.Enabled;
            }
        }

        private void DoLyricsPlayback()
        {
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
                }

                Thread.Sleep(1);
            }
        }

        private void DoVoiceUpdate()
        {
            while (!playbackFinished)
            {
                if (songMixer.CharaTracks.Count > 0)
                {
                    foreach (var control in charaContainerPanel.Controls)
                    {
                        if (control is not CharacterPositionControl chara) continue;
                        TryInvoke(() =>
                        {
                            chara.Disabled = !songMixer.CharaTracks[chara.Position].Active && !customVoiceControlCheckBox.Checked;

                            //if (customVoiceControlCheckBox.Checked)
                            //{
                            chara.BackColor = songMixer.CharaTracks[chara.Position].Enabled ?
                                Color.FromKnownColor(KnownColor.Control) : Color.FromKnownColor(KnownColor.ControlDark);
                            //}
                        });
                    }
                }

                Thread.Sleep(1);
            }
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
