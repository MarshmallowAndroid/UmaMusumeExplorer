using NAudio.Wave;

namespace UmamusumeExplorer.Controls
{
    public interface IAudioTrack
    {
        public string Name { get; }

        public WaveStream WaveStream { get; }
    }
}
