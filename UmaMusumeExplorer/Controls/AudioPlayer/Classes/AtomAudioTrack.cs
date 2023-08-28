using CriWareLibrary;
using NAudio.Wave;
using System.IO;
using UmaMusumeAudio;

namespace UmaMusumeExplorer.Controls.AudioPlayer.Classes
{
    internal class AtomAudioTrack : IAudioTrack
    {
        private readonly string awb;
        private readonly int index;

        public AtomAudioTrack(string acbPath, string awbPath, int waveIndex)
        {
            using var acbFile = File.OpenRead(acbPath);
            AcbParser acbNameLoader = new(acbFile);

            Name = acbNameLoader.LoadWaveName(waveIndex, 0, false);

            awb = awbPath;
            index = waveIndex;
        }

        public string Name { get; }

        public WaveStream WaveStream
        {
            get
            {
                AwbReader awbReader = new(File.OpenRead(awb));

                return new UmaWaveStream(awbReader, awbReader.Waves[index].WaveId);
            }
        }
    }
}
