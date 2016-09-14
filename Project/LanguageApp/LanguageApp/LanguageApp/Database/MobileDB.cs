using SQLite.Net;
using SQLite.Net.Async;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LanguageApp.Database.Models;
using LanguageApp.Database.Repositorys;

namespace LanguageApp.Database
{
    public class MobileDB
    {
        private DBGeneric db;
        /// <summary>
        ///     Manages the local database
        /// </summary>
        public MobileDB()
        {
            db = new DBGeneric();
        }

        /// <summary>
        ///     Returns a string of the last time the database was updated
        /// </summary>
        /// <returns></returns>
        public async Task<string> LastUpdatedDate()
        {
            Modification lastest = await db.Get<Modification>(0);
            return lastest.lastUpdated.ToString();
        }
        /// <summary>
        ///     Returns all WordRecords currently in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<WordRecord>> GetAllWordRecords()
        {
            return await db.GetAll<WordRecord>();
        }
        /// <summary>
        ///     Returns all WordPairs currently in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<WordPair>> GetAllWordPairs()
        {
            return await db.GetAll<WordPair>();
        }
        /// <summary>
        ///     Returns one WordRecord that matches the id passed in
        /// </summary>
        /// <returns></returns>
        public async Task<WordRecord> GetWordRecord(int id)
        {
            return await db.Get<WordRecord>(id);
        }
        /// <summary>
        ///     Returns one WordPair that matches the id passed in     // Is this needed? In what situation would you need to get 1 word pair by id? Just filter on List<WordPair>
        /// </summary>
        /// <returns></returns>
        public async Task<WordPair> GetWordPair(int id)
        {
            return await db.Get<WordPair>(id);
        }
        /// <summary>
        ///     Receives WordRecord to insert or update in the database
        /// </summary>
        public async Task SaveModel(WordRecord w)
        {
            await db.Save<WordRecord>(w);
            await db.UpdateLastUpdated();
        }
        /// <summary>
        ///     Receives WordPair to insert or update in the database
        /// </summary>
        public async Task SaveModel(WordPair w)
        {
            await db.Save<WordPair>(w);
            await db.UpdateLastUpdated();
        }
        /// <summary>
        ///     Receives a List of WordRecord to insert or update in the database
        /// </summary>
        public async Task SaveModelList(List<WordRecord> wordList)
        {
            await db.SaveList<WordRecord>(wordList);
            await db.UpdateLastUpdated();
        }
        /// <summary>
        ///     Receives a List of WordPair to insert or update in the database
        /// </summary>
        public async Task SaveModelList(List<WordPair> wordList)
        {
            await db.SaveList<WordPair>(wordList);
            await db.UpdateLastUpdated();
        }
        /// <summary>
        ///     Receives a WordRecord to delete from the database
        /// </summary>
        public async Task DeleteModel(WordRecord w)
        {
            await db.Delete<WordRecord>(w);
            await db.UpdateLastUpdated();
        }
        /// <summary>
        ///     Receives a WordPair to delete from the database
        /// </summary>
        public async Task DeleteModel(WordPair w)
        {
            await db.Delete<WordPair>(w);
            await db.UpdateLastUpdated();
        }
        /// <summary>
        ///     Receives a List of WordRecord to delete from the database
        /// </summary>
        public async Task DeleteModelList(List<WordRecord> wordList)
        {
            await db.DeleteList<WordRecord>(wordList);
            await db.UpdateLastUpdated();
        }
        /// <summary>
        ///     Receives a List of WordPair to delete from the database
        /// </summary>
        public async Task DeleteModelList(List<WordPair> wordList)
        {
            await db.DeleteList<WordPair>(wordList);
            await db.UpdateLastUpdated();
        }





    }
}
