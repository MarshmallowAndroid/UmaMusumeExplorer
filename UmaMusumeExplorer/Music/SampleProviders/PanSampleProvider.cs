using NAudio.Wave;

namespace UmaMusumeExplorer.Music.SampleProviders
{
    class PanSampleProvider : ISampleProvider
    {
        private readonly ISampleProvider sampleProvider;

        public PanSampleProvider(ISampleProvider source)
        {
            sampleProvider = source;

            if (source.WaveFormat.Channels != 2)
                throw new Exception("Must be stereo.");
        }

        public WaveFormat WaveFormat => sampleProvider.WaveFormat;

        public float Pan { get; set; }

        public int Read(float[] buffer, int offset, int count)
        {
            int read = sampleProvider.Read(buffer, offset, count);

            float left;
            float right;

            int bufferIndex = 0;
            for (int i = offset; i < count / 2; i++)
            {
                left = Pan <= 0 ? 1.0F : (1.0F - Pan) / 2.0F;
                right = Pan >= 0 ? 1.0F : (Pan + 1.0F) / 2.0F;

                buffer[bufferIndex++] *= left;
                buffer[bufferIndex++] *= right;
            }

            return read;
        }
    }
}
