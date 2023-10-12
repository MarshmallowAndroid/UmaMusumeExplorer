using ClHcaSharp;
using NAudio.Wave;

namespace UmaMusumeAudio
{
    public class HcaWaveStream : WaveStream
    {
        private readonly Stream hcaFileStream;
        private readonly BinaryReader hcaFileReader;
        private readonly HcaDecoder decoder;
        private readonly HcaInfo info;
        private readonly long dataStart;
        private readonly object positionLock = new();

        private readonly short[][] sampleBuffer;

        private long samplePosition;

        public HcaWaveStream(Stream hcaFile, ulong key)
        {
            hcaFileStream = hcaFile;
            hcaFileReader = new(hcaFile);
            decoder = new(hcaFile, key);
            info = decoder.HcaInfo;
            dataStart = hcaFile.Position;

            sampleBuffer = new short[info.ChannelCount][];
            for (int i = 0; i < info.ChannelCount; i++)
            {
                sampleBuffer[i] = new short[info.SamplesPerBlock];
            }

            Loop = info.LoopEnabled;
            LoopStartSample = info.LoopStartSample;
            LoopEndSample = info.LoopEndSample;

            WaveFormat = new WaveFormat(info.SamplingRate, info.ChannelCount);

            samplePosition = info.EncoderDelay;
            FillBuffer(samplePosition);
        }

        public HcaInfo Info => info;

        public bool Loop { get; set; }

        public long LoopStartSample { get; set; }

        public long LoopEndSample { get; set; }

        public override WaveFormat WaveFormat { get; }

        public override long Length => info.SampleCount * info.ChannelCount * sizeof(short);

        public override long Position
        {
            get
            {
                lock (positionLock)
                {
                    return (samplePosition - info.EncoderDelay) * info.ChannelCount * sizeof(short);
                }
            }
            set
            {
                lock (positionLock)
                {
                    samplePosition = value / info.ChannelCount / sizeof(short);
                    samplePosition += info.EncoderDelay;

                    if (Position < Length) FillBuffer(samplePosition);
                }
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            lock (positionLock)
            {
                int read = 0;

                for (int i = 0; i < count / info.ChannelCount / sizeof(short); i++)
                {
                    if (samplePosition - info.EncoderDelay >= LoopEndSample && Loop)
                    {
                        samplePosition = LoopStartSample + info.EncoderDelay;
                        FillBuffer(samplePosition);
                    }
                    else if (Position >= Length) break;

                    if (samplePosition % info.SamplesPerBlock == 0) FillBuffer(samplePosition);

                    for (int j = 0; j < info.ChannelCount; j++)
                    {
                        int bufferOffset = (i * info.ChannelCount + j) * sizeof(short);
                        buffer[offset + bufferOffset] = (byte)sampleBuffer[j][samplePosition % info.SamplesPerBlock];
                        buffer[offset + bufferOffset + 1] = (byte)(sampleBuffer[j][samplePosition % info.SamplesPerBlock] >> 8);

                        read += sizeof(short);
                    }

                    samplePosition++;
                }

                return read;
            }
        }

        public void ResetLoop()
        {
            Loop = info.LoopEnabled;
            LoopStartSample = info.LoopStartSample;
            LoopEndSample = info.LoopEndSample;
        }

        private void FillBuffer(long sample)
        {
            int block = (int)(sample / info.SamplesPerBlock);
            FillBuffer(block);
        }

        private void FillBuffer(int block)
        {
            if (block >= 0) hcaFileStream.Position = dataStart + block * info.BlockSize;

            if (hcaFileStream.Position < hcaFileStream.Length)
            {
                byte[] blockBytes = hcaFileReader.ReadBytes(info.BlockSize);
                if (blockBytes.Length > 0)
                {
                    //try
                    //{
                    decoder.DecodeBlock(blockBytes);
                    decoder.ReadSamples16(sampleBuffer);
                    //}
                    //catch (Exception e)
                    //{
                    //    Debug.WriteLine("HCA decoder threw an exception: " + e.Message);
                    //}
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            hcaFileStream.Dispose();

            base.Dispose(disposing);
        }

        //private void FillBuffer()
        //{
        //    if (hcaFileStream.Position >= hcaFileStream.Length)
        //        hcaFileStream.Position = dataStart;

        //    byte[] blockBytes = hcaFileReader.ReadBytes(info.BlockSize);
        //    if (blockBytes.Length > 0)
        //    {
        //        decoder.DecodeBlock(blockBytes);
        //        decoder.ReadSamples16(sampleBuffer);
        //    }
        //    else
        //    {
        //        for (int i = 0; i < sampleBuffer.Length; i++)
        //        {
        //            for (int j = 0; j < sampleBuffer[i].Length; j++)
        //            {
        //                sampleBuffer[i][j] = 0;
        //            }
        //        }
        //    }
        //}
    }
}
