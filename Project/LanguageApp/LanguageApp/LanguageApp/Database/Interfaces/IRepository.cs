using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LanguageApp.Database.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> CountRecords();
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task Save(TEntity entity);
        Task SaveList(List<TEntity> entityList);
        Task Delete(TEntity entity);
        Task DeleteList(List<TEntity> entityList);
        Task<bool> CheckExistince(TEntity entity);
    }
}
