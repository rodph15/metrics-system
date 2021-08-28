using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Metrics.Services.Domain.Interface
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includes);
        Task Save(TEntity entity);
        Task SaveMany(IEnumerable<TEntity> entity);
        void Delete(TEntity entity);
        void DeleteMany(IEnumerable<TEntity> entity);
        Task<int> CountAll();

        Task<int> SumItem(Expression<Func<TEntity, int>> where);

        Task<TEntity> FirstItem(Expression<Func<TEntity, long>> where);

        Task<TEntity> LastItem(Expression<Func<TEntity, long>> where);
    }
}
