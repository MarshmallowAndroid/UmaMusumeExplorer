using CriWareFormats;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using UmaMusumeAudio;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    class CharaTrack : ISampleProvider, IDisposable
    {
        private readonly UmaWaveStream mainUmaWaveStream;
        private readonly UmaWaveStream secondUmaWaveStream;

        private readonly PanSampleProvider mainSampleProvider;
        private readonly PanSampleProvider secondSampleProvider;

        private readonly List<Trigger> triggers = new();

        private readonly int positionIndex;

        private float[] mainBuffer;
        private float[] secondBuffer;
        private float[] targetBuffer;

        private long currentSample = 0;
        private int triggerIndex = 0;
        private float volumeMultiplier = 1.0f;

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
                long sample = (long)(partTrigger.TimeMs / 1000.0f * mainUmaWaveStream.WaveFormat.SampleRate);
                triggers.Add(
                    new Trigger(
                        sample,
                        partTrigger.MemberTracks[index],
                        partTrigger.MemberVolumes[index],
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

        public bool AlwaysSinging { get; set; }

        public int Read(float[] buffer, int offset, int count)
        {
            if (mainBuffer is null && secondBuffer is null)
            {
                mainBuffer = new float[count];
                secondBuffer = new float[count];
            }

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

                    if (triggers[triggerIndex].Volume == 999.0f)
                        volumeMultiplier = 1.0f;
                    else
                        volumeMultiplier = triggers[triggerIndex].Volume;

                    if (triggers[triggerIndex].VolumeRate != 999.0f)
                        volumeMultiplier += 0.25f * triggers[triggerIndex].VolumeRate;

                    //if (triggers[triggerIndex].Pan == 999.0f)
                    //{
                    //    mainSampleProvider.Pan = 0.0f;

                    //    if (secondSampleProvider is not null) secondSampleProvider.Pan = 0.0f;
                    //}
                    //else
                    //{
                    //    mainSampleProvider.Pan = triggers[triggerIndex].Pan;
                    //    if (secondSampleProvider is not null) secondSampleProvider.Pan = triggers[triggerIndex].Pan;

                    //    //volumeMultiplier *= (1.0f - triggers[triggerIndex].Pan);
                    //}

                    if (triggerIndex < triggers.Count - 1) triggerIndex++;
                    else break;
                }

                for (int j = 0; j < WaveFormat.Channels; j++)
                {
                    int index = i * WaveFormat.Channels + j;

                    if (AlwaysSinging && positionIndex == 0)
                    {
                        buffer[index] = mainBuffer[index];
                        if (secondBuffer is not null) buffer[index] += secondBuffer[index];
                    }
                    else if (!AlwaysSinging && targetBuffer is not null)
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
