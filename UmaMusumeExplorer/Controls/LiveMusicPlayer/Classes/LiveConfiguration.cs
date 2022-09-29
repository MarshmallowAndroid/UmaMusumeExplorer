using System.Collections.Generic;
using System.IO;

namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    static class LiveConfiguration
    {
        private static FileStream configurationFile;

        private static readonly Dictionary<int, SongConfiguration> songConfigurations = new();

        public static void SaveConfiguration(SongConfiguration songConfiguration)
        {
            songConfigurations.Clear();
            ReadConfigurationFile();

            songConfigurations[songConfiguration.SongId] = songConfiguration;
            WriteConfigurationFile();
        }

        public static SongConfiguration LoadConfiguration(int songId)
        {
            songConfigurations.Clear();
            ReadConfigurationFile();

            if (songConfigurations.ContainsKey(songId))
                return songConfigurations[songId];

            return null;
        }

        private static void OpenFile()
        {
            configurationFile = new("LiveConfiguration.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        private static void CloseFile() => configurationFile.Dispose();

        private static void ReadConfigurationFile()
        {
            OpenFile();

            BinaryReader reader = new(configurationFile);

            reader.BaseStream.Position = 0;

            if (reader.BaseStream.Length == 0)
            {
                CloseFile();
                return;
            }

            int entryCount = reader.ReadInt16();
            for (int i = 0; i < entryCount; i++)
            {
                int songId = reader.ReadInt32();
                int memberCount = reader.ReadByte();

                int[] members = new int[memberCount];
                for (int j = 0; j < memberCount; j++)
                {
                    members[j] = reader.ReadInt32();
                }

                SongConfiguration songConfiguration = new(songId, members);
                songConfigurations[songId] = songConfiguration;
            }

            CloseFile();
        }

        private static void WriteConfigurationFile()
        {
            OpenFile();

            BinaryWriter writer = new(configurationFile);
            writer.BaseStream.Position = 0;

            writer.Write((short)songConfigurations.Count);
            foreach (var songConfiguration in songConfigurations)
            {
                writer.Write(songConfiguration.Value.SongId);
                writer.Write((byte)songConfiguration.Value.Members.Length);

                foreach (var member in songConfiguration.Value.Members)
                {
                    writer.Write(member);
                }
            }

            CloseFile();
        }
    }

    class SongConfiguration
    {
        public int SongId;
        public int[] Members;

        public SongConfiguration(int songId, int[] members)
        {
            SongId = songId;
            Members = members;
        }
    }
}
