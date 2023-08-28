using CriWareLibrary;

namespace UmaMusumeExplorer.Controls.AudioPlayer.Classes
{
    record TrackComboBoxItem(string TrackName, int Index, IAudioTrack Track)
    {
        public override string ToString()
        {
            return $"{Index}: {TrackName}";
        }
    }
}
