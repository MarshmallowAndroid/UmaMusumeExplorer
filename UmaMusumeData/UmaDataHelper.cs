using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UmaMusumeData
{
    public static class UmaDataHelper
    {
        private static readonly string localLow = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low");
        private static string umaMusumeDirectory = Path.Combine(localLow, "Cygames", "umamusume");

        private static List<ManifestEntry>? manifestEntries;

        public static string UmaMusumeDirectory { get => umaMusumeDirectory; set => umaMusumeDirectory = value; }

        public static string DataDirectory => Path.Combine(UmaMusumeDirectory, "dat");

        public static string MetaFile => Path.Combine(UmaMusumeDirectory, "meta");

        public static string MasterFile => Path.Combine(UmaMusumeDirectory, "master", "master.mdb");

        public static bool CheckDirectory()
        {
            return Directory.Exists(UmaMusumeDirectory) &&
                File.Exists(MetaFile) && File.Exists(MasterFile);
        }

        public static string GetPath(ManifestEntry? entry)
        {
            if (entry is not null)
            {
                string path = Path.Combine(DataDirectory, entry.HashName[..2], entry.HashName);

                if (File.Exists(path)) return path;
                else return "";
            }
            else return "";
        }

        public static string GetPath(IEnumerable<ManifestEntry> entryList, string gameFileBaseName)
        {
            ManifestEntry? entry = entryList.FirstOrDefault(gf => gf.BaseName == gameFileBaseName);

            if (entry is not null)
                return GetPath(entry);
            else return "";
        }

        public static List<ManifestEntry> GetManifestEntries(Func<ManifestEntry, bool>? condition = null)
        {
            manifestEntries ??= GetRows<ManifestEntry>(MetaFile);

            if (condition is not null)
                return manifestEntries.Where(condition).ToList();
            else
                return manifestEntries;
        }

        public static List<T> GetMasterDatabaseRows<T>(Func<T, bool>? condition = null) where T : new()
            => GetRows(MasterFile, condition);

        private static List<T> GetRows<T>(string databaseFile, Func<T, bool>? condition = null) where T : new()
        {
            List<T> rows;

            try
            {
                SQLiteConnection connection = new(databaseFile, SQLiteOpenFlags.ReadOnly);
                TableQuery<T> table = connection.Table<T>();

                if (condition is not null)
                    rows = [.. table.Where(condition)];
                else
                    rows = [.. table];

                connection.Close();
                connection.Dispose();
            }
            catch (SQLiteException)
            {
                // for global version with missing tables
                // we'll just have to wait and see what breaks with this

                rows = [];
            }

            return rows;
        }
    }
}
