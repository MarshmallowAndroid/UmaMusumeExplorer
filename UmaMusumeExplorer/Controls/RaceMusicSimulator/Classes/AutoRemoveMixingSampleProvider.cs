using NAudio.Utils;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace UmaMusumeExplorer.Controls.RaceMusicSimulator.Classes
{
    // Modified MixingSampleProvider from NAudio that removes an input when an event triggers.
    class AutoRemoveMixingSampleProvider : ISampleProvider
    {
        private readonly List<ISampleProvider> sources;

        private float[] sourceBuffer;

        public IEnumerable<ISampleProvider> MixerInputs => sources;

        public bool ReadFully { get; set; }

        public WaveFormat WaveFormat { get; private set; }

        public event EventHandler<SampleProviderEventArgs> MixerInputEnded;

        public AutoRemoveMixingSampleProvider(WaveFormat waveFormat)
        {
            if (waveFormat.Encoding != WaveFormatEncoding.IeeeFloat)
            {
                throw new ArgumentException("Mixer wave format must be IEEE float");
            }

            sources = new List<ISampleProvider>();
            WaveFormat = waveFormat;
        }

        public AutoRemoveMixingSampleProvider(IEnumerable<ISampleProvider> sources)
        {
            this.sources = new List<ISampleProvider>();
            foreach (ISampleProvider source in sources)
            {
                AddMixerInput(source);
            }

            if (this.sources.Count == 0)
            {
                throw new ArgumentException("Must provide at least one input in this constructor");
            }
        }

        public void AddMixerInput(IWaveProvider mixerInput)
        {
            AddMixerInput(mixerInput.ToSampleProvider());
        }

        public void AddMixerInput(ISampleProvider mixerInput)
        {
            lock (sources)
            {
                if (sources.Count >= 1024)
                {
                    throw new InvalidOperationException("Too many mixer inputs");
                }

                sources.Add(mixerInput);
            }

            if (WaveFormat is null)
            {
                WaveFormat = mixerInput.WaveFormat;
            }
            else if (WaveFormat.SampleRate != mixerInput.WaveFormat.SampleRate || WaveFormat.Channels != mixerInput.WaveFormat.Channels)
            {
                throw new ArgumentException("All mixer inputs must have the same WaveFormat");
            }
        }

        public void AddMixerInput(IEventSampleProvider mixerInput)
        {
            lock (sources)
            {
                if (sources.Count >= 1024)
                {
                    throw new InvalidOperationException("Too many mixer inputs");
                }

                mixerInput.OnSampleProviderEvent += (source) =>
                {
                    RemoveMixerInput(mixerInput);
                };

                sources.Add(mixerInput);
            }

            if (WaveFormat is null)
            {
                WaveFormat = mixerInput.WaveFormat;
            }
            else if (WaveFormat.SampleRate != mixerInput.WaveFormat.SampleRate || WaveFormat.Channels != mixerInput.WaveFormat.Channels)
            {
                throw new ArgumentException("All mixer inputs must have the same WaveFormat");
            }
        }

        public void RemoveMixerInput(ISampleProvider mixerInput)
        {
            lock (sources)
            {
                sources.Remove(mixerInput);
            }
        }

        public void RemoveAllMixerInputs()
        {
            lock (sources)
            {
                sources.Clear();
            }
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int num = 0;
            sourceBuffer = BufferHelpers.Ensure(sourceBuffer, count);
            lock (sources)
            {
                for (int num2 = sources.Count - 1; num2 >= 0; num2--)
                {
                    ISampleProvider sampleProvider = sources[num2];
                    int num3 = sampleProvider.Read(sourceBuffer, 0, count);
                    int num4 = offset;
                    for (int i = 0; i < num3; i++)
                    {
                        if (i >= num)
                        {
                            buffer[num4++] = sourceBuffer[i];
                        }
                        else
                        {
                            buffer[num4++] += sourceBuffer[i];
                        }
                    }

                    num = Math.Max(num3, num);
                    if (num3 < count)
                    {
                        MixerInputEnded?.Invoke(this, new SampleProviderEventArgs(sampleProvider));
                        sources.RemoveAt(num2);
                    }
                }
            }

            if (ReadFully && num < count)
            {
                int num5 = offset + num;
                while (num5 < offset + count)
                {
                    buffer[num5++] = 0F;
                }

                num = count;
            }

            return num;
        }
    }
}
