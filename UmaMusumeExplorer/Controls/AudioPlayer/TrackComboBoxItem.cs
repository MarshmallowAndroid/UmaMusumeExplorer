using CriWareFormats;

namespace UmaMusumeExplorer.Controls.AudioPlayer
{
    class TrackComboBoxItem
    {
        public string TrackName { get; set; }

        public int WaveId { get; set; }

        public AwbReader AwbReader { get; set; }

        public override string ToString()
        {
            return TrackName;
        }
    }
}
