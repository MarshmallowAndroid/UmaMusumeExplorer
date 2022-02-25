using SQLite;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1)
            {
                string localLow = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow");
                string umaMusumeDirectory = Path.Combine(localLow, "Cygames", "umamusume");

                SQLiteConnection connection = new(Path.Combine(umaMusumeDirectory, "meta"));
                string dataDirectory = Path.Combine(umaMusumeDirectory, "dat");
                string outputDirectory = args[0];

                var realFiles = Directory.GetFiles(dataDirectory, "*", SearchOption.AllDirectories).ToList();
                var gameFiles = connection.Table<GameFile>().ToList();
                gameFiles.Sort((gf1, gf2) => { return string.Compare(gf1.Name, gf2.Name); });

                //int fileNumber = 1;
                foreach (var gameFile in gameFiles)
                {
                    //Task.Run(() => Console.WriteLine("Processing file {0} of {1}...", fileNumber, gameFiles.Count));

                    string dataFileName = gameFile.Hash;
                    string dataFilePath = Path.Combine(dataDirectory, dataFileName[..2], dataFileName);
                    string realFileName = gameFile.Name.TrimStart('/');
                    if (gameFile.Category.StartsWith("manifest")) realFileName += ".manifest";
                    string realFilePath = Path.Combine(outputDirectory, realFileName);
                    string destinationDirectory;

                    if (!string.IsNullOrEmpty(Path.GetDirectoryName(realFileName)))
                        destinationDirectory = Path.Combine(outputDirectory, Path.GetDirectoryName(realFileName));
                    else destinationDirectory = outputDirectory;   

                    Directory.CreateDirectory(destinationDirectory);

                    if (!File.Exists(realFilePath) && File.Exists(dataFilePath)) File.Copy(dataFilePath, realFilePath);
                    
                    //fileNumber++;
                }
            }
        }
    }
}
