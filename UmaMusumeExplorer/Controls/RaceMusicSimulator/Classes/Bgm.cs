using CriWareFormats;
using System;
using System.Collections.Generic;
using System.IO;
using UmaMusumeAudio;
using UmaMusumeFiles;

namespace UmaMusumeExplorer.Controls.RaceMusicSimulator.Classes
{
    public class Bgm : IDisposable
    {
        private readonly AwbReader awbReader;

        public Bgm(IEnumerable<GameAsset> gameAssetList, string cuesheetName, string cueName)
        {
            string lower = cuesheetName.ToLower();
            string awbPath = UmaDataHelper.GetPath(gameAssetList, lower + ".awb");
            string acbPath = UmaDataHelper.GetPath(gameAssetList, lower + ".acb");

            awbReader = new(File.OpenRead(awbPath));

            AcbReader acbReader = new(File.OpenRead(acbPath));

            int targetWaveID = -1;
            foreach (var wave in awbReader.Waves)
            {
                string waveName = acbReader.GetWaveName(wave.WaveId, 0, false);

                if (waveName.Contains(cueName))
                {
                    targetWaveID = wave.WaveId;
                    break;
                }
            }

            acbReader.Dispose();

            UmaWaveStream = new UmaWaveStream(awbReader, targetWaveID);
        }

        public UmaWaveStream UmaWaveStream { get; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            awbReader.Dispose();
        }
    }
}
