using NAudio.Wave;
using System;

namespace UmaMusumeExplorer.Controls.AudioPlayer.Classes
{
    internal interface IAudioTrack
    {
        public string Name { get; }

        public WaveStream WaveStream { get; }
    }
}
