using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.Common.Classes
{
    internal class ExtendedSampleProvider : IExtendedSampleProvider
    {
        private readonly WaveStream source;
        private readonly ISampleProvider sampleProvider;

        public ExtendedSampleProvider(WaveStream waveStream)
        {
            source = waveStream;
            sampleProvider = waveStream.ToSampleProvider();
        }

        public WaveFormat WaveFormat => sampleProvider.WaveFormat;

        public long Position { get => source.Position; set => source.Position = value; }

        public long Length => source.Length;

        public TimeSpan CurrentTime => source.CurrentTime;

        public TimeSpan TotalTime => source.TotalTime;

        public int Read(float[] buffer, int offset, int count) => sampleProvider.Read(buffer, offset, count);
    }
}
