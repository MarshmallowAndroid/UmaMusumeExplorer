namespace UmaMusumeExplorer.Controls.LiveMusicPlayer.Classes
{
    static class LiveConfiguration
    {
        private static readonly Dictionary<int, SongConfiguration> songConfigurations = new();

        public static void SaveConfiguration(SongConfiguration songConfiguration)
        {
            songConfigurations.Clear();
            ReadConfigurationFile();

            songConfigurations[songConfiguration.SongId] = songConfiguration;
            WriteConfigurationFile();
        }

        public static SongConfiguration? LoadConfiguration(int songId)
        {
            songConfigurations.Clear();
            ReadConfigurationFile();

            if (songConfigurations.ContainsKey(songId))
                return songConfigurations[songId];

            return null;
        }

        private static FileStream OpenFile()
        {
            return new("LiveConfiguration.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        private static void ReadConfigurationFile()
        {
            FileStream configurationFile = OpenFile();
            BinaryReader reader = new(configurationFile);

            reader.BaseStream.Position = 0;

            if (reader.BaseStream.Length == 0)
            {
                configurationFile.Dispose();
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
                bool sfx = reader.ReadBoolean();

                SongConfiguration songConfiguration = new(songId, members, sfx);
                songConfigurations[songId] = songConfiguration;
            }

            configurationFile.Dispose();
        }

        private static void WriteConfigurationFile()
        {
            FileStream configurationFile = OpenFile();
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
                writer.Write(songConfiguration.Value.Sfx);
            }

            configurationFile.Dispose();
        }
    }

    record SongConfiguration(int SongId, int[] Members, bool Sfx);
}
