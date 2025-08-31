using CriWareLibrary;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using UmamusumeAudio;

namespace LiveMusicPlayerCli
{
    class CharaTrack : ISampleProvider, IDisposable
    {
        private readonly UmaWaveStream mainUmaWaveStream;
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

        public CharaTrack(AwbReader charaAwb, List<PartTrigger> partTriggers, int index)
        {
            mainUmaWaveStream = new(charaAwb, 0);
            mainSampleProvider = new(mainUmaWaveStream.ToSampleProvider());

            if (charaAwb.Waves.Count > 1)
            {
                secondUmaWaveStream = new(charaAwb, 1);
                secondSampleProvider = new(secondUmaWaveStream.ToSampleProvider());
            }

            foreach (var partTrigger in partTriggers)
            {
                long sample = (long)(partTrigger.TimeMs / 1000.0F * mainUmaWaveStream.WaveFormat.SampleRate);
                float volume = partTrigger.MemberVolumes[index] != 999.0F ? partTrigger.MemberVolumes[index] : 1.0F;
                volume += partTrigger.VolumeRate != 999.0F ? 0.25F * partTrigger.VolumeRate : 0.0F;

                triggers.Add(
                    new Trigger(
                        sample,
                        partTrigger.MemberTracks[index],
                        volume,
                        partTrigger.MemberPans[index],
                        partTrigger.VolumeRate));
            }

            positionIndex = index;
        }

        public WaveFormat WaveFormat => mainSampleProvider.WaveFormat;

        public long Position
        {
            get
            {
                return mainUmaWaveStream.Position;
            }
            set
            {
                lock (readLock)
                {
                    mainUmaWaveStream.Position = value;
                    if (secondUmaWaveStream is not null) secondUmaWaveStream.Position = value;

                    currentSample = mainUmaWaveStream.Position / mainUmaWaveStream.WaveFormat.Channels / (mainUmaWaveStream.WaveFormat.BitsPerSample / 8);

                    triggerIndex = 0;
                }
            }
        }

        public bool CenterOnly { get; set; }

        public bool AlwaysSing { get; set; }

        public int Read(float[] buffer, int offset, int count)
        {
            if (mainBuffer is null && secondBuffer is null ||
                mainBuffer?.Length != count && secondBuffer?.Length != count)
            {
                mainBuffer = new float[count];
                secondBuffer = new float[count];
            }

            int mainRead = 0;

            lock (readLock)
            {
                if (mainBuffer is not null)
                    mainRead = mainSampleProvider.Read(mainBuffer, offset, count);

                if (secondBuffer is not null)
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

                    if (CenterOnly && positionIndex == 0 || AlwaysSing)
                    {
                        if (mainBuffer is not null) buffer[index] = mainBuffer[index];
                        if (secondBuffer is not null) buffer[index] += secondBuffer[index];
                    }
                    else if (!CenterOnly && targetBuffer is not null)
                        buffer[index] = targetBuffer[index] * volumeMultiplier;
                    else
                        buffer[index] = 0;
                }

                currentSample++;
            }

            return mainRead;
        }

        public void Dispose()
        {
            mainUmaWaveStream.Dispose();
            secondUmaWaveStream?.Dispose();
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
