using System;
using System.Collections.Generic;
using System.Text;

using LanguageApp.iOS.Database;
using LanguageApp.Database;
using Xamarin.Forms;
using SQLite.Net;
using System.IO;
using SQLite.Net.Async;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(SQLiteService))]
namespace LanguageApp.iOS.Database
{
    public class SQLiteService : ISQLiteConnection
    {
        private const string FILENAME = "language.db3";
        
        public SQLiteService() { }

        /// <summary>
        ///     Connects to the database for an iOS device
        /// </summary>
        /// <returns>SQLiteConnection</returns>
        public SQLiteAsyncConnection CreateConnection()
        {
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentPath, "..", "Library");
            string path = Path.Combine(documentPath, FILENAME);

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();

            // ---  Storing DateTime as ticks   ---  //
            SQLiteConnectionString conString = new SQLiteConnectionString(path, true);
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, conString));

            return connection;
        }
    }
}
