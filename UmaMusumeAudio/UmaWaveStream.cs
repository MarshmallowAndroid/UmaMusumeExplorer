﻿using NAudio.Wave;
using System;
using System.IO;
using CriWareFormats;
using UmaMusumeAudio.Hca;

namespace UmaMusumeAudio
{
    public class UmaWaveStream : WaveStream
    {
        /*
         * Open Umamusume > umamusume_Data > resources.assets with a hex editor.
         * Check the results when finding the string "StreamingAssets".
         * The key should be near a string named "cri_auth". 
         */
        private const ulong umaMusumeKey = 75923756697503;

        private readonly HcaWaveStream hcaWaveStream;
        private readonly object lockObject = new();

        public UmaWaveStream(AwbReader awbReader, int waveId)
        {
            Stream awbSubfile = awbReader.GetWaveSubfileStream(awbReader.Waves.Find((wave) => wave.WaveId == waveId));
            hcaWaveStream = new(awbSubfile, MixKey(umaMusumeKey, awbReader.Subkey));
        }

        public override WaveFormat WaveFormat => hcaWaveStream.WaveFormat;

        public bool Loop { get => hcaWaveStream.Loop; set { hcaWaveStream.Loop = value; } }

        public override long Length => hcaWaveStream.Length;

        public override long Position { get => hcaWaveStream.Position; set => hcaWaveStream.Position = value; }

        public override int Read(byte[] buffer, int offset, int count)
        {
            lock (lockObject)
            {
                return hcaWaveStream.Read(buffer, offset, count);
            }
        }

        private static ulong MixKey(ulong key, ushort subkey) =>
            key * (((ulong)subkey << 16) | ((ushort)~subkey + 2u));

        protected override void Dispose(bool disposing)
        {
            lock (lockObject)
            {
                base.Dispose(disposing);
            }
        }
    }
}
