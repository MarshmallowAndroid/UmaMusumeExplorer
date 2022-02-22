using CriWareFormats;
using NAudio.Wave;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UmaMusumeAudio;

namespace PlayerCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            // Initialize the output device.
            using var waveOut = new WaveOutEvent();

            bool directRead = args.Length > 0;

            string dataDirectory = "";
            List<GameFile> gameFiles = null;

            if (!directRead)
            {
                // Should be the same for all users.
                string localLow = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low");
                string umaMusumeDirectory = Path.Combine(localLow, "Cygames", "umamusume");
                string metaFile = Path.Combine(umaMusumeDirectory, "meta");

                // UmaMusume meta file is just an SQLite database.
                SQLiteConnection connection = new(metaFile);
                dataDirectory = Path.Combine(Path.GetDirectoryName(metaFile), "dat");

                // Queries the list of game files. Schema of the table is defined in the GameFile class.
                gameFiles = connection.Table<GameFile>()
                    .Where((gf) => gf.Name.Contains("bgm_") /*&& !gf.Name.Contains("race")*/ && !gf.Name.Contains("live"))
                    .ToList();
                // Sort game files by their names.
                gameFiles.Sort((gf1, gf2) => { return string.Compare(gf1.Name, gf2.Name); });

                // Store filtered game files in a new list (we only want BGM).
                //var filtered = new List<GameFile>();

                // Close the SQLite connection.
                connection.Close();
                connection.Dispose();
            }

            //foreach (var gameFile in gameFiles)
            //{
            //    string dataFileName = gameFile.DataFileName;
            //    // Get the path of the files. All the files are stored in the 'dat' directory
            //    // followed by the folder name according to the file's first two letters.
            //    //
            //    // Example: 
            //    // 5V2DTDTE37XT6FXDZ6G4Z75DUMU6JBH6 = <UmaMusume_dir>\dat\5V\5V2DTDTE37XT6FXDZ6G4Z75DUMU6JBH6
            //    string dataFilePath = Path.Combine(dataDirectory, dataFileName.Substring(0, 2), dataFileName);
            //    // The real file name strings start with a '//' so remove that.
            //    string realFileName = gameFile.RealFileName.TrimStart('/');

            //    // Get all BGM file names, minus the ones for races and live stages.
            //    if (realFileName.Contains("bgm_") && !realFileName.Contains("race") && !realFileName.Contains("live"))
            //    {
            //        // Add the waveform bank file (.awb) and the cue file (.acb).
            //        filtered.Add(gameFile);
            //    }
            //}

            //// Clear the list since we got what we needed.
            //gameFiles.Clear();
            //gameFiles = null;

            List<string> fileNames = new List<string>();

            // List the files.
            foreach (var gameFile in gameFiles)
            {
                // Show the bank files (.awb) and not the cue files (.acb).
                if (gameFile.Name.EndsWith(".awb")) fileNames.Add(gameFile.Name);
            }

            int index = 0;
            bool autoFileChange = false;

            // Main loop
            while (true)
            {
                string awbPath = "";
                string acbPath = "";

                if (!directRead)
                {
                    // List the files.
                    if (!autoFileChange)
                    {
                        Console.Clear();

                        foreach (var fileName in fileNames)
                        {
                            // Show the bank files (.awb) and not the cue files (.acb).
                            Console.WriteLine(fileName);
                        }
                    }

                    GameFile result;
                    GameFile resultAcb;
                    while (!autoFileChange)
                    {
                        Console.Write("\nSelect file: ");

                        // Select by search because selecting by index is too tedious.
                        string query = Console.ReadLine();

                        // Get the index of the queried file name, if there is a result.
                        index = fileNames.FindIndex((fn) => fn.Contains(query));

                        //result = gameFiles.Find((gf) => gf.Name.Contains(query) && gf.Name.EndsWith(".awb"));
                        //resultAcb = gameFiles.Find((gf) => gf.Name.Contains(query) && gf.Name.EndsWith(".acb"));

                        // Both should have results.
                        //if (result != null && resultAcb != null) break;

                        if (index >= 0) break;
                    }
                    Console.WriteLine();

                    string awbFileName = fileNames[index];
                    // Get the bank file, and its partner cue file (for the track names).
                    result = gameFiles.Find((gf) => gf.Name == awbFileName);
                    resultAcb = gameFiles.Find((gf) => gf.Name == awbFileName.Substring(0, awbFileName.IndexOf(".awb")) + ".acb");

                    // Get the data file paths (the "obfuscated" ones).
                    awbPath = Path.Combine(dataDirectory, result.Hash.Substring(0, 2), result.Hash);
                    acbPath = Path.Combine(dataDirectory, resultAcb.Hash.Substring(0, 2), resultAcb.Hash);
                }
                else
                {
                    awbPath = args[0];
                    acbPath = awbPath.Remove(awbPath.Length - 4) + ".acb";
                }

                // Read the files.
                AwbReader awb = new(File.OpenRead(awbPath));
                AcbReader acb = new(File.OpenRead(acbPath));

                // List the tracks.
                for (int i = 0; i < awb.Waves.Count; i++)
                {
                    Console.WriteLine("{0,-4} {1}", i, acb.GetWaveName(awb.Waves[i].WaveId, 0, awb.IsEmbedded));
                }
                Console.WriteLine();

                int restore = Console.CursorTop;

                ConsoleKeyInfo key = new();

                while (true)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = restore;

                    Console.Write(new StringBuilder().Append(' ', Console.BufferWidth).ToString());

                    Console.CursorLeft = 0;
                    Console.CursorTop = restore;

                    WaveStream waveStream;
                    if (awb.Waves.Count > 1 && !autoFileChange)
                    {
                        Console.Write("Select track: ");
                        bool trackValid = int.TryParse(Console.ReadLine(), out int input);
                        if (!trackValid) break;
                        Console.WriteLine();

                        waveStream = new UmaWaveStream(awb, input);
                    }
                    else
                    {
                        waveStream = new UmaWaveStream(awb, 0);
                    }

                    //waveOut.Init(waveStream);
                    waveOut.Init(new VolumeWaveProvider16(waveStream) { Volume = 2.0f });
                    waveOut.Play();

                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        if (Console.KeyAvailable)
                        {
                            key = Console.ReadKey(true);

                            waveOut.Stop();
                            waveStream.Dispose();
                            waveStream = null;

                            if (key.Key == ConsoleKey.Q) return;
                            //else if (key.Key == ConsoleKey.F) break;
                        }

                        if (waveStream != null) ProgressBar((int)waveStream.Position, (int)waveStream.Length);

                        Thread.Sleep(100);
                    }

                    Console.CursorLeft = 0;
                    Console.CursorTop = restore;

                    Console.Write(new StringBuilder().Append(' ', Console.BufferWidth).ToString());

                    Console.CursorLeft = 0;
                    Console.CursorTop = restore;

                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        index--;
                        autoFileChange = true;
                        break;
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        index++;
                        autoFileChange = true;
                        break;
                    }

                    autoFileChange = false;
                    if (key.Key != ConsoleKey.T) break;
                }
            }
        }

        private static string DisplayName(List<string> names)
        {
            StringBuilder name = new();
            for (int j = 0; j < names.Count; j++)
            {
                name.Append(names[j]);
                if (j < names.Count - 1)
                {
                    name.Append(", ");
                }
            }

            return name.ToString();
        }

        private static void ProgressBar(int value, int max)
        {
            int restoreX = Console.CursorLeft;
            int restoreY = Console.CursorTop;

            int totalWidth = 50;
            int widthMax = totalWidth - 2;
            int position = (int)((double)((double)value / max) * widthMax);
            StringBuilder progressBar = new();
            progressBar.Append('[');
            for (int i = 0; i < widthMax; i++)
            {
                if (i <= position) progressBar.Append('=');
                else progressBar.Append(' ');
            }
            progressBar.Append(']');

            string final = progressBar.ToString();

            //Console.Write(new string(' ', Console.BufferWidth));
            //Console.CursorLeft = restoreX;
            //Console.CursorTop = restoreY;

            Console.Write(final + new string(' ', Console.BufferWidth - final.Length));

            Console.CursorLeft = restoreX;
            Console.CursorTop = restoreY;
        }
    }
}
