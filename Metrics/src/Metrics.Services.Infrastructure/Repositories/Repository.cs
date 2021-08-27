﻿using Metrics.Services.Domain.Interface;
using Metrics.Services.Infrastructure.Context;
using Metrics.Services.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Metrics.Services.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MetricsDbContext _dbContext;

        public Repository(MetricsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(TEntity entity) => _dbContext.Add(entity);

        public void SaveMany(IEnumerable<TEntity> entity) => _dbContext.AddRange(entity);

        public void Delete(TEntity entity) => _dbContext.Remove(entity);

        public void DeleteMany(IEnumerable<TEntity> entity) => _dbContext.RemoveRange(entity);

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> where) => await _dbContext.Set<TEntity>().Where(where).ToListAsync();

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>() as IQueryable<TEntity>;
            query = query.EagerLoad(includes);

            return await query.Where(where).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>() as IQueryable<TEntity>;
            query = query.EagerLoad(includes);

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(int id) => await _dbContext.Set<TEntity>().FindAsync(id);

    }
}
