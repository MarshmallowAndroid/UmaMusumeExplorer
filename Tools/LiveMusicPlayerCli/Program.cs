using System.Reflection;
using System.Text;
using UmamsumeData.Tables;
using UmamsumeData;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System;

namespace LiveMusicPlayerCli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (args.Length == 0 || args.Contains("-h") || args.Contains("--help"))
                ShowHelp();
            else
                ParseArguments(args);
        }

        static void ParseArguments(string[] args)
        {
            int musicId = 0;
            int[]? singers = null;
            bool random = false;

            string exportFileName = "";

            int argIndex;
            for (argIndex = 0; argIndex < args.Length; argIndex++)
            {
                if (args[argIndex].Equals("-l") || args[argIndex].Equals("--list-songs"))
                {
                    ListSongs();
                    return;
                }

                if (args[argIndex].Equals("-e") || args[argIndex].Equals("--export"))
                {
                    exportFileName = args[argIndex + 1];
                    argIndex += 2;
                }

                if (args[argIndex].Equals("-r") || args[argIndex].Equals("--random"))
                {
                    random = true;
                }

                bool musicIdFound = int.TryParse(args[argIndex], out int foundMusicId);
                if (musicIdFound)
                {
                    argIndex += 1;
                    musicId = foundMusicId;
                    break;
                }
            }

            int givenSingerCount = args.Length - argIndex;
            if (givenSingerCount > 0)
            {
                singers = new int[givenSingerCount];
                for (int singersIndex = 0; singersIndex < givenSingerCount; singersIndex++)
                {
                    bool isInt = int.TryParse(args[singersIndex + argIndex], out int singerId);

                    if (isInt)
                        singers[singersIndex] = singerId;
                }
            }

            try
            {
                Load(musicId, singers, random, exportFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        static void Load(int musicId, int[]? singers, bool isRandom, string exportFileName)
        {
            if (musicId == 0)
            {
                Random randomIndex = new();
                IEnumerable<LiveData> liveDatas = AssetTables.LiveDatas.Where(ld => ld.HasLive == 1);
                musicId = liveDatas.ElementAt(randomIndex.Next(0, liveDatas.Count())).MusicId;
            }

            LiveBuilder liveBuilder = new(musicId);
            int expectedMembers = liveBuilder.GetSingingMemberCount();

            if (singers is null && !isRandom)
            {
                ShowSongInfo(musicId, liveBuilder.GetSingingMemberCount());
                return;
            }

            if (isRandom)
            {
                singers = new int[liveBuilder.GetSingingMemberCount()];

                Random randomIndex = new();

                IEnumerable<LivePermissionData> livePermissionData = GetLivePermissionData(musicId);
                for (int i = 0; i < singers.Length; i++)
                {
                    while (true)
                    {
                        int charaId = livePermissionData.ElementAt(randomIndex.Next(0, livePermissionData.Count())).CharaId;
                        if (!singers.Contains(charaId))
                        {
                            singers[i] = charaId;
                            break;
                        }
                    }
                }
            }
            else if (singers?.Length == expectedMembers || singers?.Length == 1)
            {
                if (singers.Length == 1)
                    liveBuilder.Solo = true;
            }
            else
                throw new Exception("Incorrect number of singers.");

            singers.CopyTo(liveBuilder.Singers, 0);

            ISampleProvider sampleProvider = liveBuilder.Build();

            bool export = !exportFileName.Equals(string.Empty);

            Console.WriteLine($"{(export ? "Exporting" : "Playing")} {AssetTables.GetText(AssetTables.LiveNameTextDatas, musicId)}\n\nSingers:");
            for (int i = 0; i < singers.Length; i++)
            {
                Console.WriteLine($"{AssetTables.GetText(AssetTables.CharaNameTextDatas, singers[i])}" +
                    $" (CV. {AssetTables.GetText(AssetTables.CharaVoiceNameTextDatas, singers[i])})");
            }
            Console.Write("\nPress Ctrl+C to terminate.");

            if (export)
            {
                WaveFileWriter.CreateWaveFile16(exportFileName, sampleProvider);
            }
            else
            {
                WaveOutEvent outputDevice = new();
                outputDevice.Init(sampleProvider);
                outputDevice.Play();

                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }

            Console.WriteLine("\nDone.");
        }

        static void ShowSongInfo(int musicId, int singingMembers)
        {
            string songTitle = AssetTables.GetText(AssetTables.LiveNameTextDatas, musicId);
            string songInfo = AssetTables.GetText(AssetTables.LiveInfoTextDatas, musicId).Replace("\\n", "\n");

            IEnumerable<LivePermissionData> livePermissionData = GetLivePermissionData(musicId);

            Console.WriteLine(
                $"""
                {songTitle}
                {songInfo}

                Singers:
                """);

            foreach (var chara in livePermissionData)
            {
                Console.WriteLine($"{chara.CharaId}: {AssetTables.GetText(AssetTables.CharaNameTextDatas, chara.CharaId)}" +
                    $" (CV. {AssetTables.GetText(AssetTables.CharaVoiceNameTextDatas, chara.CharaId)})");
            }

            Console.WriteLine("\nRequired singer count: " + singingMembers);
        }

        static IEnumerable<LivePermissionData> GetLivePermissionData(int musicId)
        {
            IEnumerable<LivePermissionData> livePermissionData = AssetTables.LivePermissionDatas.Where(lpd => lpd.MusicId == musicId);

            if (!livePermissionData.Any())
            {
                livePermissionData = new List<LivePermissionData>();
                var matches = AssetTables.AudioAssetEntries.Where(ga => ga.BaseName.StartsWith($"snd_bgm_live_{musicId}_chara_") && ga.BaseName.EndsWith(".awb"));
                foreach (var audioAsset in matches)
                {
                    int charaId = int.Parse(audioAsset.BaseName.Remove(0, $"snd_bgm_live_{musicId}_chara_".Length)[..4]);
                    ((List<LivePermissionData>)livePermissionData).Add(new LivePermissionData() { MusicId = musicId, CharaId = charaId });
                }
            }

            return livePermissionData;
        }

        static void ListSongs()
        {
            foreach (var liveData in AssetTables.LiveDatas.Where(ld => ld.HasLive == 1))
            {
                Console.WriteLine(liveData.MusicId + ": " + AssetTables.GetText(AssetTables.LiveNameTextDatas, liveData.MusicId));
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine(
                $"""
                Umamusume Live Music Player CLI
                ================================

                Usage: {Path.GetFileName(Environment.GetCommandLineArgs()[0])} [options] <song ID> [<singer1> <singer2> ...]

                Options:
                    -h|--help                   Shows this text.
                    -l|--list-songs             Shows a list of currently registered songs.
                    -e|--export <file name>     Render the specified configuration to a 16-bit PCM WAV file.
                    -r|--random                 Random singers, and song if the song ID is not specified.
                    -a|--force-all-sing         Force all members to sing.

                To display song information, do not specify any singers.

                For random singers, specify "random" for the singer arguments.
                For solos, specify only one singer.
                """);
        }
    }
}