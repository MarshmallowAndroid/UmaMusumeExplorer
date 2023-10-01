using CriWareLibrary;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using UmaMusumeAudio;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    class CharaTrack : ISampleProvider, IDisposable
    {
        private readonly UmaWaveStream? mainUmaWaveStream;
        private readonly UmaWaveStream? secondUmaWaveStream;

        private readonly PanSampleProvider mainSampleProvider;
        private readonly PanSampleProvider? secondSampleProvider;

        private readonly List<Trigger> triggers = new();

        private readonly int positionIndex;

        private float[]? mainBuffer;
        private float[]? secondBuffer;
        private float[]? targetBuffer;

        private long currentSample = 0;
        private int triggerIndex = 0;
        private float volumeMultiplier = 1.0F;

        private readonly object readLock = new();

        public CharaTrack(WaveFormat targetWaveFormat, AwbReader charaAwb, List<PartTrigger> partTriggers, int index)
        {
            mainUmaWaveStream = new(charaAwb, 0);
            mainSampleProvider = new(EnsureEqualSampleRate(targetWaveFormat, mainUmaWaveStream));

            if (charaAwb.Waves.Count > 1)
            {
                secondUmaWaveStream = new(charaAwb, 1);
                secondSampleProvider = new(EnsureEqualSampleRate(targetWaveFormat, secondUmaWaveStream));
            }

            foreach (var partTrigger in partTriggers)
            {
                long sample = (long)(partTrigger.TimeMs / 1000.0F * mainSampleProvider.WaveFormat.SampleRate);
                float volume = partTrigger.MemberVolumes[index] != 999.0F ? partTrigger.MemberVolumes[index] : 1.0F;
                volume += partTrigger.VolumeRate != 999.0F ? partTrigger.VolumeRate * 0.25F : 0.0F;

                triggers.Add(
                    new Trigger(
                        sample,
                        partTrigger.MemberTracks[index],
                        volume,
                        partTrigger.MemberPans[index],
                        partTrigger.VolumeRate));
            }

            positionIndex = index;

            WaveFormat = targetWaveFormat;
        }

        public WaveFormat WaveFormat { get; }

        public long Position
        {
            get
            {
                return mainUmaWaveStream?.Position ?? 0;
            }
            set
            {
                lock (readLock)
                {
                    if (mainUmaWaveStream is null) return;

                    long fixedValue = value * mainUmaWaveStream.WaveFormat.SampleRate / WaveFormat.SampleRate;

                    mainUmaWaveStream.Position = fixedValue;
                    if (secondUmaWaveStream is not null) secondUmaWaveStream.Position = fixedValue;

                    currentSample = value / mainUmaWaveStream.WaveFormat.Channels / (mainUmaWaveStream.WaveFormat.BitsPerSample / 8);

                    triggerIndex = 0;
                }
            }
        }

        public bool Enabled { get; set; }

        public bool ForceSing { get; set; }

        public bool Active { get; private set; }

        public int Read(float[] buffer, int offset, int count)
        {
            mainBuffer = EnsureBuffer(mainBuffer, count);
            secondBuffer = EnsureBuffer(secondBuffer, count);

            int mainRead;

            lock (readLock)
            {
                mainRead = mainSampleProvider.Read(mainBuffer, offset, count);
                secondSampleProvider?.Read(secondBuffer, offset, count);
            }

            for (int i = 0; i < count / WaveFormat.Channels; i++)
            {
                while (currentSample >= triggers[triggerIndex].Sample)
                {
                    int activeTrack = triggers[triggerIndex].Track;

                    if (activeTrack == 1)
                        targetBuffer = mainBuffer;
                    else if (activeTrack == 2)
                        targetBuffer = secondBuffer;
                    else
                        targetBuffer = null;

                    volumeMultiplier = triggers[triggerIndex].Volume;

                    //if (triggers[triggerIndex].VolumeRate != 999.0F)
                    //    volumeMultiplier += 0.25F * triggers[triggerIndex].VolumeRate;

                    //if (triggers[triggerIndex].Pan == 999.0F)
                    //{
                    //    mainSampleProvider.Pan = 0.0F;

                    //    if (secondSampleProvider is not null) secondSampleProvider.Pan = 0.0F;
                    //}
                    //else
                    //{
                    //    mainSampleProvider.Pan = triggers[triggerIndex].Pan;
                    //    if (secondSampleProvider is not null) secondSampleProvider.Pan = triggers[triggerIndex].Pan;

                    //    //volumeMultiplier *= (1.0F - triggers[triggerIndex].Pan);
                    //}

                    if (triggerIndex < triggers.Count - 1) triggerIndex++;
                    else break;
                }

                for (int j = 0; j < WaveFormat.Channels; j++)
                {
                    int index = i * WaveFormat.Channels + j;

                    if (ForceSing)
                    {
                        buffer[index] = mainBuffer[index];
                        if (secondBuffer is not null) buffer[index] += secondBuffer[index];
                    }
                    else if (targetBuffer is not null)
                        buffer[index] = targetBuffer[index] * volumeMultiplier;
                    else
                        buffer[index] = 0;

                    if (!Enabled)
                        buffer[index] = 0;

                    Active = targetBuffer is not null;
                }

                currentSample++;
            }


            return mainRead;
        }

        public void Dispose()
        {
            mainUmaWaveStream?.Dispose();
            secondUmaWaveStream?.Dispose();
        }

        private static float[] EnsureBuffer(float[]? buffer, int length)
        {
            if (buffer == null || buffer.Length < length)
                return new float[length];
            return buffer;
        }

        private ISampleProvider EnsureEqualSampleRate(WaveFormat targetWaveFormat, WaveStream waveStream)
        {
            if (mainUmaWaveStream?.WaveFormat.SampleRate != targetWaveFormat.SampleRate)
                return new WdlResamplingSampleProvider(waveStream.ToSampleProvider(), targetWaveFormat.SampleRate);
            else
                return waveStream.ToSampleProvider();
        }

        private struct Trigger
        {
            public long Sample;
            public int Track;
            public float Volume;
            public float Pan;
            public float VolumeRate;

            public Trigger(long sample, int track, float volume, float pan, float volumeRate)
            {
                Sample = sample;
                Track = track;
                Volume = volume;
                Pan = pan;
                VolumeRate = volumeRate;
            }
        }
    }
}
