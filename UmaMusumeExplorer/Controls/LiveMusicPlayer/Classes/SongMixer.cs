using CriWareFormats;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using UmaMusumeAudio;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    class SongMixer : ISampleProvider, IDisposable
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

                long sample = (long)(partTrigger.TimeMs / 1000.0f * WaveFormat.SampleRate);
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

        public bool CenterOnly
        {
            get
            {
                bool centerOnly = false;

                lock (readLock)
                {
                    foreach (var charaTrack in charaTracks)
                    {
                        centerOnly = charaTrack.CenterOnly;
                    }
                }

                return centerOnly;
            }

            set
            {
                lock (readLock)
                {
                    foreach (var charaTrack in charaTracks)
                    {
                        charaTrack.CenterOnly = value;
                    }
                }
            }
        }

        public bool AllSing
        {
            get
            {
                bool alwaysSinging = false;

                lock (readLock)
                {
                    foreach (var charaTrack in charaTracks)
                    {
                        alwaysSinging = charaTrack.AlwaysSing;
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
                        charaTrack.AlwaysSing = value;
                    }
                }
            }
        }
        }

        public bool MuteBgm { get; set; }

        public bool MuteVoices { get; set; }

        public void InitializeCharaTracks(List<AwbReader> charaAwbs)
        {
            lock (readLock)
            {
                bool alwaysSing = false;
                bool centerSolo = false;

                foreach (var charaTrack in charaTracks)
                {
                    alwaysSing = charaTrack.AlwaysSing;
                    centerSolo = charaTrack.CenterOnly;
                    charaTrack.Dispose();
                }

                charaTracks.Clear();

                int currentIndex = 0;
                foreach (var charaAwb in charaAwbs)
                {
                    CharaTrack charaTrack = new(charaAwb, partTriggers, currentIndex++)
                    {
                        AlwaysSing = alwaysSing,
                        CenterOnly = centerSolo,
                        Position = okeWaveStream.Position
                    };
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

                    if (MuteVoices) continue;

                    for (int i = offset; i < count; i++)
                    {
                        buffer[i] += charaTracksBuffer[i];
                    }
                }

                read = okeSampleProvider.Read(okeBuffer, offset, count);
                }

                for (int i = offset; i < count / WaveFormat.Channels; i++)
                {
                    while (currentSample >= volumeTriggers[volumeTriggerIndex].Sample)
                    {
                    if (AllSing)
                        volumeMultiplier = allActiveVolume;
                        else
                            volumeMultiplier = 1.0f / (volumeTriggers[volumeTriggerIndex].ActiveSingers + 1) + 0.5f;

                        if (volumeTriggerIndex < volumeTriggers.Count - 1) volumeTriggerIndex++;
                        else break;
                    }

                    for (int j = 0; j < WaveFormat.Channels; j++)
                    {
                    buffer[i * WaveFormat.Channels + j] *= CenterOnly ? 1.0f : volumeMultiplier;
                    }

                    currentSample++;
                }

                for (int i = offset; i < count; i++)
                {
                    buffer[i] += MuteBgm ? 0 : okeBuffer[i];
                    buffer[i] *= 1.5f;
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