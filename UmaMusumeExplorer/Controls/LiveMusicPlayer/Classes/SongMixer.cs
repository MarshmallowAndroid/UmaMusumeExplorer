using CriWareFormats;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using UmaMusumeAudio;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    internal class SongMixer : ISampleProvider, IDisposable
    {
        private readonly UmaWaveStream okeWaveStream;
        private readonly ISampleProvider okeSampleProvider;

        private readonly List<CharaTrack> charaTracks = new();
        private readonly List<PartTrigger> partTriggers = new();
        private readonly List<VolumeTrigger> volumeTriggers = new();

        private readonly object readLock = new();

        private float[] charaTracksBuffer;
        private float[] okeBuffer;
        private float volumeMultiplier = 1.0f;

        private long currentSample = 0;
        private int volumeTriggerIndex = 0;

        public SongMixer(AwbReader okeAwb, List<PartTrigger> parts)
        {
            okeWaveStream = new(okeAwb, 0);
            okeSampleProvider = okeWaveStream.ToSampleProvider();

            partTriggers = parts;

            foreach (var partTrigger in partTriggers)
            {
                int activeSingers = 0;
                foreach (var track in partTrigger.MemberTracks)
                {
                    if (track > 0)
                        activeSingers++;
                }

                long sample = (long)(partTrigger.TimeMs / 1000.0d * WaveFormat.SampleRate);
                volumeTriggers.Add(new VolumeTrigger(sample, activeSingers));
            }
        }

        public WaveFormat WaveFormat => okeSampleProvider.WaveFormat;

        public long Position
        {
            get
            {
                return okeWaveStream.Position;
            }
            set
            {
                lock (readLock)
                {
                    okeWaveStream.Position = value;
                    foreach (var charaTrack in charaTracks)
                    {
                        charaTrack.Position = value;
                    }
                    currentSample = okeWaveStream.Position / okeWaveStream.WaveFormat.Channels / (okeWaveStream.WaveFormat.BitsPerSample / 8);
                    volumeTriggerIndex = 0;
                }
            }
        }

        public long Length => okeWaveStream.Length;

        public TimeSpan CurrentTime => okeWaveStream.CurrentTime;

        public TimeSpan TotalTime => okeWaveStream.TotalTime;

        public bool ForceSolo
        {
            get
            {
                bool alwaysSinging = false;

                lock (readLock)
                {
                    foreach (var charaTrack in charaTracks)
                    {
                        alwaysSinging = charaTrack.AlwaysSinging;
                    }
                }

                return alwaysSinging;
            }

            set
            {
                lock (readLock)
                {
                    foreach (var charaTrack in charaTracks)
                    {
                        charaTrack.AlwaysSinging = value;
                    }
                }
            }
        }

        public void InitializeCharaTracks(List<AwbReader> charaAwbs)
        {
            lock (readLock)
            {
                foreach (var charaTrack in charaTracks)
                {
                    charaTrack.Dispose();
                }

                charaTracks.Clear();

                int currentIndex = 0;
                foreach (var charaAwb in charaAwbs)
                {
                    CharaTrack charaTrack = new(charaAwb, partTriggers, currentIndex++);
                    charaTrack.Position = okeWaveStream.Position;
                    charaTracks.Add(charaTrack);
                }
            }
        }

        public int Read(float[] buffer, int offset, int count)
        {
            if (charaTracksBuffer is null && okeBuffer is null)
            {
                charaTracksBuffer = new float[count];
                okeBuffer = new float[count];
            }

            for (int i = 0; i < count; i++)
            {
                buffer[i] = 0.0f;
            }

            int read;

            lock (readLock)
            {
                foreach (var charaTrack in charaTracks)
                {
                    charaTrack.Read(charaTracksBuffer, offset, count);

                    for (int i = offset; i < count; i++)
                    {
                        buffer[i] += charaTracksBuffer[i];
                    }
                }

                for (int i = offset; i < count / WaveFormat.Channels; i++)
                {
                    while (currentSample >= volumeTriggers[volumeTriggerIndex].Sample)
                    {
                        if (volumeTriggers[volumeTriggerIndex].ActiveSingers == 1)
                            volumeMultiplier = 1.0f;
                        else
                            volumeMultiplier = 1.0f / (volumeTriggers[volumeTriggerIndex].ActiveSingers + 1) + 0.5f;

                        if (volumeTriggerIndex < volumeTriggers.Count - 1) volumeTriggerIndex++;
                        else break;
                    }

                    for (int j = 0; j < WaveFormat.Channels; j++)
                    {
                        buffer[i * WaveFormat.Channels + j] *= ForceSolo ? 1.0f : volumeMultiplier;
                    }

                    currentSample++;
                }

                read = okeSampleProvider.Read(okeBuffer, offset, count);
                for (int i = offset; i < count; i++)
                {
                    buffer[i] += okeBuffer[i];
                    buffer[i] *= 1.5f;
                }
            }

            return read;
        }

        public void Dispose()
        {
            okeWaveStream.Dispose();

            foreach (var charaTrack in charaTracks)
            {
                charaTrack.Dispose();
            }
        }

        private struct VolumeTrigger
        {
            public long Sample;
            public int ActiveSingers;

            public VolumeTrigger(long sample, int activeSingers)
            {
                Sample = sample;
                ActiveSingers = activeSingers;
            }
        }
    }
}