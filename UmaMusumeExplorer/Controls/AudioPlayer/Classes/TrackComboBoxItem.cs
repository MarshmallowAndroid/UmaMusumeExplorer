using CriWareFormats;

namespace UmaMusumeExplorer.Controls.AudioPlayer.Classes
{
    class TrackComboBoxItem
    {
        public string TrackName { get; set; }

        public int WaveID { get; set; }

        public AwbReader AwbReader { get; set; }

        public override string ToString()
        {
            return TrackName;
        }
    }
}
