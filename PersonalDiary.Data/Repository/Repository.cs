using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonalDiary.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;
        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }
        public async Task<T> GetAsync(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }           
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            if (include != null)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync();

        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate=null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            if (include != null)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            if (include != null)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }
        public async Task<T> Add(T newEntity)
        {
            return DbSet.Add(newEntity).Entity;
        }
        public async Task<bool> AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
            return true;
        }
        public async Task<bool> Update(T originalEntity, T newEntity)
        {
            Context.Entry(originalEntity).CurrentValues.SetValues(newEntity);
            return true;
        }
        public async Task<bool> UpdateRange(IEnumerable<T> newEntitie)
        {
            Context.UpdateRange(newEntitie);
            return true;
        }
        public async Task<bool> Remove(T entity)
        {
            DbSet.Remove(entity);
            return true;
        }
        public async Task<bool> Remove(Expression<Func<T, bool>> predicate)
        {
            var objects =await FindAsync(predicate);
            DbSet.RemoveRange(objects);
            return true;
        }
        public async Task<bool> RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
            return true;
        }
    }
}
