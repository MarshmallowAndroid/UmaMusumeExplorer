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
        private static readonly string umaMusumeDirectory = Path.Combine(localLow, "Cygames", "umamusume");
        private static readonly string dataDirectory = Path.Combine(umaMusumeDirectory, "dat");
        private static readonly string metaFile = Path.Combine(umaMusumeDirectory, "meta");
        private static readonly string masterFile = Path.Combine(umaMusumeDirectory, "master", "master.mdb");

        private static List<ManifestEntry>? manifestEntries;

        public static string GetPath(ManifestEntry? entry)
        {
            if (entry is not null)
            {
                string path = Path.Combine(dataDirectory, entry.HashName[..2], entry.HashName);

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
            manifestEntries ??= GetRows<ManifestEntry>(metaFile);

            if (condition is not null)
                return manifestEntries.Where(condition).ToList();
            else
                return manifestEntries;
        }

        public static List<T> GetMasterDatabaseRows<T>(Func<T, bool>? condition = null) where T : new()
            => GetRows(masterFile, condition);

        private static List<T> GetRows<T>(string databaseFile, Func<T, bool>? condition = null) where T : new()
        {
            try
            {
                SQLiteConnection connection = new(databaseFile, SQLiteOpenFlags.ReadOnly);

                List<T> rows;
                if (condition is not null)
                    rows = connection.Table<T>().Where(condition).ToList();
                else
                    rows = connection.Table<T>().ToList();

                connection.Close();
                connection.Dispose();

                return rows;
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
    }
}
