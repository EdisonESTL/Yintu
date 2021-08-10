using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;

namespace Yintu.DataBase
{
    public static class DataBase
    {
        public const string dbFileName = "DbYintu.db3";

        public const SQLiteOpenFlags flags =
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.SharedCache;

        public static string DbPath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, dbFileName);
            }
        }
    }
}
