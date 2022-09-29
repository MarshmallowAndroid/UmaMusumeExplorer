using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaMusumeExplorer.Controls.RaceMusicSimulator.Classes
{
    // Sample provider interface that uses events to signal the end of sample modification (fades, delays, etc.)
    interface IEventSampleProvider : ISampleProvider
    {
        public delegate void SampleProvideEventHandler(ISampleProvider source);
        public event SampleProvideEventHandler OnSampleProviderEvent;
    }
}
