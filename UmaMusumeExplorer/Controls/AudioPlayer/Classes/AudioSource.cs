﻿namespace UmaMusumeExplorer.Controls.AudioPlayer.Classes
{
    public abstract class AudioSource
    {
        private IAudioTrack[]? tracks;

        public abstract string Name { get; }

        public abstract int TrackCount { get; }

        public IAudioTrack[] Tracks
        {
            get
            {
                tracks ??= InitializeTracks();
                return tracks;
            }
        }

        protected abstract IAudioTrack[] InitializeTracks();
    }
}
