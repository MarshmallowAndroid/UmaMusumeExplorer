﻿using NAudio.Wave;

namespace UmaMusumeExplorer.Controls.AudioPlayer.Classes
{
    public interface IAudioTrack
    {
        public string Name { get; }

        public WaveStream WaveStream { get; }
    }
}
