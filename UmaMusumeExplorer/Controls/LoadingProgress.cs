using AssetStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls
{
    internal class LoadingProgress : IProgress<int>
    {
        readonly Action<int> reportProgress;

        public LoadingProgress(Action<int> action)
        {
            reportProgress = action;
        }

        public void Report(int value)
        {
            reportProgress.Invoke(value);
        }
    }
}
