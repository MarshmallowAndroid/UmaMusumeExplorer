using CriWareLibrary;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using UmaMusumeAudio;
using UmaMusumeExplorer.Music.SampleProviders;

namespace UmaMusumeExplorer.Music.Live
{
    class SongMixer : IExtendedSampleProvider, IDisposable
    {
        private UmaWaveStream okeWaveStream;
        private ISampleProvider okeSampleProvider;
        private readonly List<PartTrigger> partTriggers;
        private readonly List<VolumeTrigger> volumeTriggers = new();
        private UmaWaveStream? voiceOverWaveStream;
        private ISampleProvider? voiceOverSampleProvider;
        private int voiceTrigger;

        private readonly object readLock = new();

        private bool customMode;
        private float[]? okeBuffer;
        private float[]? charaTracksBuffer;
        private float[]? voiceOverBuffer;
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
                    if (track != 0)
                        activeSingers++;
                }

                if (partTrigger.VolumeRate == 1F)
                    activeSingers = 0;

                long sample = (long)(partTrigger.TimeMs / 1000F * WaveFormat.SampleRate);
                volumeTriggers.Add(new VolumeTrigger(sample, activeSingers));
            }
        }

        public List<CharaTrack> CharaTracks { get; } = [];

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

                    AdjustVoiceOverPosition();
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
                bool[] forceSingStates = new bool[charaAwbs.Length];
                bool[] forceExStates = new bool[charaAwbs.Length];

                for (int i = 0; i < enabledStates.Length; i++)
                {
                    if (CharaTracks.Count == charaAwbs.Length)
                    {
                        enabledStates[i] = CharaTracks[i].Enabled;
                        forceSingStates[i] = CharaTracks[i].ForceSing;
                        forceExStates[i] = CharaTracks[i].ForceEx;
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
                        ForceSing = forceSingStates[i],
                        ForceEx = forceExStates[i]
                    };

                    CharaTracks.Add(newCharaTrack);
                }
            }
        }

        public void InitializeVoiceOver(AwbReader voiceOverAwb, int timeMs)
        {
            lock (readLock)
            {
                voiceTrigger = (int)(timeMs / 1000F * WaveFormat.SampleRate);
                voiceOverWaveStream = new(voiceOverAwb, 0);

                AdjustVoiceOverPosition();
            }
        }

        public void ChangeOke(AwbReader okeAwb)
        {
            lock (readLock)
            {
                long position = okeWaveStream.Position;

                okeWaveStream.Dispose();
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
            voiceOverBuffer = EnsureBuffer(voiceOverBuffer, count);

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

                voiceOverSampleProvider?.Read(voiceOverBuffer, offset, count);
            }

            for (int i = offset; i < count / WaveFormat.Channels; i++)
            {
                if (volumeTriggers.Count > 0)
                {
                    while (currentSample >= volumeTriggers[volumeTriggerIndex].Sample)
                    {
                        volumeMultiplier = volumeTriggers[volumeTriggerIndex].Volume;

                        if (volumeTriggerIndex < volumeTriggers.Count - 1) volumeTriggerIndex++;
                        else break;
                    }
                }

                for (int j = 0; j < WaveFormat.Channels; j++)
                {
                    int index = i * WaveFormat.Channels + j;
                    buffer[index] *= CustomMode ? CalculateVolume(active) : volumeMultiplier;
                    buffer[index] += MuteBgm ? 0 : okeBuffer[index];
                    buffer[index] += voiceOverBuffer[index];
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

        private void AdjustVoiceOverPosition()
        {
            if (voiceOverWaveStream is null) return;

            long newTrigger = 0;
            if (currentSample < voiceTrigger)
            {
                newTrigger = voiceTrigger - currentSample;
                voiceOverWaveStream.Position = 0;
            }
            else
            {
                voiceOverWaveStream.Position = Math.Min((currentSample - voiceTrigger)
                    * voiceOverWaveStream.WaveFormat.Channels
                    * (voiceOverWaveStream.WaveFormat.BitsPerSample / 8),
                    voiceOverWaveStream.Length);
            }

            voiceOverSampleProvider = new OffsetSampleProvider(voiceOverWaveStream.ToSampleProvider())
            {
                DelayBySamples = (int)newTrigger * WaveFormat.Channels
            };
        }

        private static float[] EnsureBuffer(float[]? buffer, int length)
        {
            if (buffer == null || buffer.Length < length)
                return new float[length];
            return buffer;
        }

        private static float CalculateVolume(int activeSources)
        {
            if (activeSources < 1) return 1F;
            return 1F / (float)Math.Sqrt(activeSources);
        }

        private struct VolumeTrigger
        {
            public long Sample;
            public float Volume;

            public VolumeTrigger(long sample, int activeSingers)
            {
                Sample = sample;
                if (activeSingers == 0)
                    Volume = 1F;
                else
                    Volume = CalculateVolume(activeSingers);
            }
        }
    }
}