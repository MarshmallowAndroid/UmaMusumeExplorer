using NAudio.Wave;
using System;
using System.IO;
using CriWareLibrary;

namespace PlayerCli
{
    public class UmaWaveStream : WaveStream
    {
        private const ulong umaMusumeKey = 75923756697503;

        private readonly HcaWaveStream hcaWaveStream;

        public UmaWaveStream(AwbReader awbReader, int waveId)
        {
            Stream awbSubfile = awbReader.GetWaveSubfileStream(awbReader.Waves.Find((wave) => wave.WaveId == waveId));
            hcaWaveStream = new(awbSubfile, MixKey(umaMusumeKey, awbReader.Subkey));
        }

        public override WaveFormat WaveFormat => hcaWaveStream.WaveFormat;

        public bool Loop { get => hcaWaveStream.Loop; set { hcaWaveStream.Loop = value; } }

        public long LoopStartSample { get => hcaWaveStream.LoopStartSample; set { hcaWaveStream.LoopStartSample = value; } }

        public long LoopEndSample { get => hcaWaveStream.LoopEndSample; set { hcaWaveStream.LoopEndSample = value; } }

        public override long Length => hcaWaveStream.Length;

        public override long Position { get => hcaWaveStream.Position; set => hcaWaveStream.Position = value; }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return hcaWaveStream.Read(buffer, offset, count);
        }

        public void ResetLoop() => hcaWaveStream.ResetLoop();

        private static ulong MixKey(ulong key, ushort subkey) =>
            key * (((ulong)subkey << 16) | ((ushort)~subkey + 2u));

        protected override void Dispose(bool disposing)
        {
            hcaWaveStream.Dispose();

            base.Dispose(disposing);
        }
    }
}
