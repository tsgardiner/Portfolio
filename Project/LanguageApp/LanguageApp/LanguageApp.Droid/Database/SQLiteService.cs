using System;

using LanguageApp.Droid.Database;
using LanguageApp.Database;
using Xamarin.Forms;
using System.IO;
using SQLite.Net.Async;
using SQLite.Net;

[assembly: Dependency(typeof(SQLiteService))]
namespace LanguageApp.Droid.Database
{
    public class SQLiteService : ISQLiteConnection
    {
        private const string FILENAME = "language.db3";

        public SQLiteService() { }

        /// <summary>
        ///     Connects to the database for an Andriod device 
        /// </summary>
        /// <returns>SQLiteConnection</returns>
        public SQLiteAsyncConnection CreateConnection()
        {
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, FILENAME);

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

            // ---  Storing DateTime as ticks   ---  //
            SQLiteConnectionString conString = new SQLiteConnectionString(path, true);
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(() => new SQLite.Net.SQLiteConnectionWithLock(platform, conString));

            return connection;
        }
    }
}