using AssetStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.CharacterInfo.Classes
{
    internal class AssetStudioProgress : IProgress<int>
    {
        readonly Action<int> reportProgress;

        public AssetStudioProgress(Action<int> action)
        {
            reportProgress = action;
        }

        public void Report(int value)
        {
            reportProgress.Invoke(value);
        }
    }
}
