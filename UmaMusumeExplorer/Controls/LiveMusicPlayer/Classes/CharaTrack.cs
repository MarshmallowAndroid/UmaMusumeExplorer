using CriWareFormats;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmaMusumeAudio;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    internal class CharaTrack : ISampleProvider, IDisposable
    {
        private readonly UmaWaveStream mainUmaWaveStream;
        private readonly UmaWaveStream secondUmaWaveStream;

        private readonly PanSampleProvider mainSampleProvider;
        private readonly PanSampleProvider secondSampleProvider;

        private readonly List<Trigger> triggers = new();

        private float[] mainBuffer;
        private float[] secondBuffer;
        private float[] targetBuffer;

        private long currentSample = 0;
        private int triggerIndex = 0;
        private float volumeMultiplier = 1.0f;

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
                long sample = (long)(partTrigger.TimeMs / 1000.0d * mainUmaWaveStream.WaveFormat.SampleRate);
                triggers.Add(
                    new Trigger(
                        sample,
                        partTrigger.MemberTracks[index],
                        partTrigger.MemberVolumes[index],
                        partTrigger.MemberPans[index]));
            }
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
                mainUmaWaveStream.Position = value;
                if (secondUmaWaveStream is not null) secondUmaWaveStream.Position = value;

                currentSample = mainUmaWaveStream.Position / mainUmaWaveStream.WaveFormat.Channels / (mainUmaWaveStream.WaveFormat.BitsPerSample / 8);

                triggerIndex = 0;
            }
        }

        public bool Singing { get; private set; }

        public int Read(float[] buffer, int offset, int count)
        {
            if (mainBuffer is null && secondBuffer is null)
            {
                mainBuffer = new float[count];
                secondBuffer = new float[count];
            }

            int mainRead = mainSampleProvider.Read(mainBuffer, offset, count);
            secondSampleProvider?.Read(secondBuffer, offset, count);

            for (int i = 0; i < count / WaveFormat.Channels; i++)
            {
                while (currentSample >= triggers[triggerIndex].Sample)
                {
                    int activeTrack = triggers[triggerIndex].Track;

                    Singing = activeTrack == 1;

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

                    if (triggers[triggerIndex].Pan == 999.0f)
                    {
                        mainSampleProvider.Pan = 0.0f;
                        if (secondSampleProvider is not null) secondSampleProvider.Pan = 0.0f;
                    }
                    else
                    {
                        mainSampleProvider.Pan = triggers[triggerIndex].Pan;
                        if (secondSampleProvider is not null) secondSampleProvider.Pan = triggers[triggerIndex].Pan;
                    }

                    if (triggerIndex < triggers.Count - 1) triggerIndex++;
                    else break;
                }

                for (int j = 0; j < WaveFormat.Channels; j++)
                {
                    int index = i * WaveFormat.Channels + j;

                    if (targetBuffer is null) buffer[index] = 0;
                    else buffer[index] = targetBuffer[index] * volumeMultiplier;
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

            public Trigger(long sample, int track, float volume, float pan)
            {
                Sample = sample;
                Track = track;
                Volume = volume;
                Pan = pan;
            }
        }
    }
}
