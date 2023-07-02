using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.AudioPlayer.Classes
{
    internal abstract class AudioSource
    {
        private IAudioTrack[] tracks;

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
