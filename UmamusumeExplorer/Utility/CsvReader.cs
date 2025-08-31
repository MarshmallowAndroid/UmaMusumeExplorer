using System.Text;

namespace UmamusumeExplorer.Utility
{
    internal class CsvReader : StreamReader
    {
        public CsvReader(Stream stream) : base(stream) { }

        public string ReadCsvLine()
        {
            StringBuilder stringBuilder = new();
            bool withinQuotes = false;

            int read;
            while ((read = Read()) != -1)
            {
                char c = (char)read;

                if (c == '"')
                    withinQuotes = !withinQuotes;

                if (c == '\n' && !withinQuotes) break;

                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
    }
}
