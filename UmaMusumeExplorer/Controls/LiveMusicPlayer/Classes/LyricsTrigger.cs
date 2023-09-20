using System.Collections.Generic;
using System.Text;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    class LyricsTrigger
    {
        public int TimeMs { get; }

        public string Lyrics { get; }

        public LyricsTrigger(string lyricsCsvLine)
        {
            string[] columns = Split(lyricsCsvLine, ',');
            TimeMs = int.Parse(columns[0]);
            Lyrics = columns[1]
                .Replace("[COMMA]", ",")
                .Replace("&&", "&")
                .Replace("\\n", "\n");
        }

        private string[] Split(string toSplit, char splitChar)
        {
            List<string> splitStrings = new();
            StringBuilder splitStringBuilder = new();

            bool withinQuotes = false;

            for (int i = 0; i < toSplit.Length; i++)
            {
                char c = toSplit[i];

                if (c == '"') withinQuotes = !withinQuotes;

                if (!withinQuotes && c == splitChar)
                {
                    splitStrings.Add(splitStringBuilder.ToString());
                    splitStringBuilder.Clear();
                }
                else
                    splitStringBuilder.Append(c);
            }

            splitStrings.Add(splitStringBuilder.ToString());
            return splitStrings.ToArray();
        }
    }
}
