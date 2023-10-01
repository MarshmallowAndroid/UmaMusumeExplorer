using CriWareLibrary;
using NAudio.Wave;
using UmaMusumeAudio;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    class SongMixer : ISampleProvider, IDisposable
    {
        private UmaWaveStream okeWaveStream;
        private ISampleProvider okeSampleProvider;
        private readonly List<PartTrigger> partTriggers = new();
        private readonly List<VolumeTrigger> volumeTriggers = new();

        private readonly object readLock = new();

        private bool customMode;
        private float[]? charaTracksBuffer;
        private float[]? okeBuffer;
        private float volumeMultiplier = 1.0F;

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

                long sample = (long)(partTrigger.TimeMs / 1000.0F * WaveFormat.SampleRate);
                volumeTriggers.Add(new VolumeTrigger(sample, activeSingers));
            }
        }

        public List<CharaTrack> CharaTracks { get; } = new();

        public bool MuteBgm { get; set; }

        public bool CustomMode
        {
            get => customMode;
            set
            {
                customMode = value;
                foreach (var charaTracks in CharaTracks)
                {
                    charaTracks.ForceSing = customMode;
                }
            }
        }

        public bool MuteVoices { get; set; }

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
                    foreach (var charaTrack in CharaTracks)
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

        public void InitializeCharaTracks(AwbReader[] charaAwbs)
        {
            lock (readLock)
            {
                bool[] enabledStates = new bool[charaAwbs.Length];
                bool[] alwaysSingStates = new bool[charaAwbs.Length];

                for (int i = 0; i < enabledStates.Length; i++)
                {
                    if (CharaTracks.Count == charaAwbs.Length)
                    {
                        enabledStates[i] = CharaTracks[i].Enabled;
                        alwaysSingStates[i] = CharaTracks[i].ForceSing;
                    }
                    else
                    {
                        enabledStates[i] = true;
                    }
                }

                CharaTracks.Clear();

                int currentIndex = 0;
                for (int i = 0; i < charaAwbs.Length; i++)
                {
                    CharaTrack newCharaTrack = new(WaveFormat, charaAwbs[i], partTriggers, currentIndex++)
                    {
                        Position = okeWaveStream.Position,
                        Enabled = enabledStates[i],
                        ForceSing = alwaysSingStates[i]
                    };

                    CharaTracks.Add(newCharaTrack);
                }
            }
        }

        public void ChangeOke(AwbReader okeAwb)
        {
            lock (readLock)
            {
                long position = okeWaveStream.Position;

                okeWaveStream = new(okeAwb, 0)
                {
                    Position = position
                };
                okeSampleProvider = okeWaveStream.ToSampleProvider();
            }
        }

        public int Read(float[] buffer, int offset, int count)
        {
            okeBuffer = EnsureBuffer(okeBuffer, count);
            charaTracksBuffer = EnsureBuffer(charaTracksBuffer, count);

            for (int i = 0; i < count; i++)
            {
                buffer[i] = 0.0F;
            }

            int read;
            int active = 0;

            lock (readLock)
            {
                foreach (var charaTrack in CharaTracks)
                {
                    charaTrack.Read(charaTracksBuffer, offset, count);

                    if (MuteVoices) continue;

                    for (int i = offset; i < count; i++)
                    {
                        buffer[i] += charaTracksBuffer[i];
                    }

                    if (charaTrack.Enabled) active++;
                }

                read = okeSampleProvider.Read(okeBuffer, offset, count);
            }

            for (int i = offset; i < count / WaveFormat.Channels; i++)
            {
                while (currentSample >= volumeTriggers[volumeTriggerIndex].Sample)
                {
                    volumeMultiplier = volumeTriggers[volumeTriggerIndex].Volume;

                    if (volumeTriggerIndex < volumeTriggers.Count - 1) volumeTriggerIndex++;
                    else break;
                }

                for (int j = 0; j < WaveFormat.Channels; j++)
                {
                    int index = i * WaveFormat.Channels + j;
                    buffer[index] *= CustomMode ? (1.0F / (active + 1) + 0.5F) : volumeMultiplier;
                    buffer[index] += MuteBgm ? 0 : okeBuffer[index];
                }

                currentSample++;
            }

            return read;
        }

        public void Dispose()
        {
            okeWaveStream.Dispose();

            foreach (var charaTrack in CharaTracks)
            {
                charaTrack.Dispose();
            }
        }

        private static float[] EnsureBuffer(float[]? buffer, int length)
        {
            if (buffer == null || buffer.Length < length)
                return new float[length];
            return buffer;
        }

        private struct VolumeTrigger
        {
            public long Sample;
            public float Volume;

            public VolumeTrigger(long sample, int activeSingers)
            {
                Sample = sample;
                Volume = 1.0F / (activeSingers + 1) + 0.5F;
            }
        }
    }
}