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

        public static string GetPath(GameAsset? gameFile)
        {
            if (gameFile is not null)
            {
                string path = Path.Combine(dataDirectory, gameFile.Hash[..2], gameFile.Hash);

                if (File.Exists(path)) return path;
                else return "";
            }
            else return "";
        }

        public static string GetPath(IEnumerable<GameAsset> gameAssetList, string gameFileBaseName)
        {
            GameAsset? gameFile = gameAssetList.FirstOrDefault(gf => gf.BaseName == gameFileBaseName);

            if (gameFile is not null)
                return GetPath(gameFile);
            else return "";
        }

        public static List<GameAsset> GetGameAssetDataRows(Func<GameAsset, bool>? condition = null)
            => GetRows(metaFile, condition);

        public static List<T> GetMasterDatabaseRows<T>(Func<T, bool>? condition = null) where T : new()
            => GetRows(masterFile, condition);

        private static List<T> GetRows<T>(string databaseFile, Func<T, bool>? condition = null) where T : new()
        {
            SQLiteConnection connection = new(databaseFile);

            List<T> rows;
            if (condition is not null)
                rows = connection.Table<T>().Where(condition).ToList();
            else
                rows = connection.Table<T>().ToList();

            connection.Close();
            connection.Dispose();

            return rows;
        }
    }
}
