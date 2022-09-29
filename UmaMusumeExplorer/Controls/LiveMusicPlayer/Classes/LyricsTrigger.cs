namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    class LyricsTrigger
    {
        public int TimeMs { get; }

        public string Lyrics { get; }

        public LyricsTrigger(string lyricsCsvLine)
        {
            string[] columns = lyricsCsvLine.Split(',');
            TimeMs = int.Parse(columns[0]);
            Lyrics = columns[1]
                .Replace("[COMMA]", ",")
                .Replace("&", "&&");
        }
    }
}
