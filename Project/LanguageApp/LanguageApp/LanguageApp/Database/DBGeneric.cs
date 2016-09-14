using LanguageApp.Database.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageApp.Database.Repositorys
{
    public class DBGeneric
    {
        protected readonly SQLiteAsyncConnection con;
        //protected static object locker = new object();  //  Can't lock async tasks incase of deadlocks
        // Establish connection in constructor ??
        public DBGeneric()
        {
            con = DependencyService.Get<ISQLiteConnection>().CreateConnection();
            CreateTablesAsync();
        }

        public async void CreateTablesAsync()
        {
            await con.CreateTablesAsync<WordRecord, WordPair, Modification>();
        }

        public async Task<int> CountRecords<TEntity>() where TEntity : class, IModel
        {
            return await con.Table<TEntity>().CountAsync();
        }

        public async Task<TEntity> Get<TEntity>(int id) where TEntity : class, IModel
        {
            return await con.GetAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : class, IModel
        {
            return await con.Table<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> FindList<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IModel
        {
            return await con.Table<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IModel
        {
            return await con.Table<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }
        /// <summary>
        ///     Inserts or updates a entity if it already exists
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Save<TEntity>(TEntity entity) where TEntity : class, IModel
        {
            if (await CheckExistince(entity))
                await con.UpdateAsync(entity);
            else
                await con.InsertAsync(entity);
        }

        // Can do singularly without list of TEntity 
        public async Task SaveList<TEntity>(List<TEntity> entityList) where TEntity : class, IModel
        {
            foreach (TEntity entity in entityList)
            {
                await Save(entity);
            }
        }

        // Could be <TEntity> on delete
        public async Task Delete<TEntity>(TEntity entity) where TEntity : class, IModel
        {
            if (await CheckExistince(entity))
                await con.DeleteAsync(entity);
            else
                Debug.WriteLine("Delete Failed - Entity doesn't exist");
        }

        public async Task DeleteList<TEntity>(List<TEntity> entityList) where TEntity : class, IModel
        {
            foreach (TEntity entity in entityList)
            {
                await Delete(entity);
            }
        }
        /// <summary>
        ///     Checks if an entity already exists in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> CheckExistince<TEntity>(TEntity entity) where TEntity : class, IModel
        {
            var exists = await con.Table<TEntity>()
                            .Where(x => x.id == entity.id)
                            .FirstOrDefaultAsync();
            if (exists == null)
                return false;
            else
                return true;
        }

        public async Task UpdateLastUpdated()
        {
            Modification lastModified = new Modification()
            {
                id = 0,
                lastUpdated = DateTime.Now
            };
            await Save<Modification>(lastModified);
        }



    }
}
