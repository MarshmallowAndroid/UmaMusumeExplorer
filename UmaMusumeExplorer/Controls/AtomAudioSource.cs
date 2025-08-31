using CriWareLibrary;

namespace UmaMusumeExplorer.Controls
{
    internal class AtomAudioSource : AudioSource
    {
        private readonly string acb;
        private readonly string awb;

        private readonly AwbReader awbReader;

        public AtomAudioSource(string name, string acbPath, string awbPath)
        {
            Name = name;
            acb = acbPath;
            awb = awbPath;

            awbReader = new(File.OpenRead(awbPath));

            TrackCount = awbReader.Waves.Count;
        }

        public override string Name { get; }

        public override int TrackCount { get; }

        protected override IAudioTrack[] InitializeTracks()
        {
            AtomAudioTrack[] tracks = new AtomAudioTrack[TrackCount];

            for (int i = 0; i < TrackCount; i++)
            {
                tracks[i] = new AtomAudioTrack(acb, awb, i);
            }

            return tracks;
        }
    }
}