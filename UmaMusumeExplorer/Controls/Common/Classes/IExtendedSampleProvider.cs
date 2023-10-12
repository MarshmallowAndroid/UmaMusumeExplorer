using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.Common.Classes
{
    internal interface IExtendedSampleProvider : ISampleProvider
    {
        public long Position { get; set; }

        public long Length { get; }

        public TimeSpan CurrentTime { get; }

        public TimeSpan TotalTime { get; }
    }
}
