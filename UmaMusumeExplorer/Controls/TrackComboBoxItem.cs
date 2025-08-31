namespace UmaMusumeExplorer.Controls
{
    record TrackComboBoxItem(string TrackName, int Index, IAudioTrack Track)
    {
        public override string ToString()
        {
            return $"{Index}: {TrackName}";
        }
    }
}
