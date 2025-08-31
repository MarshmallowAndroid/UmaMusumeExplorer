using NAudio.Wave;

namespace UmamusumeExplorer.Music.SampleProviders
{
    // Sample provider interface that uses events to signal the end of sample modification (fades, delays, etc.)
    interface IEventSampleProvider : ISampleProvider
    {
        public delegate void SampleProvideEventHandler(ISampleProvider source);
        public event SampleProvideEventHandler OnSampleProviderEvent;
    }
}
