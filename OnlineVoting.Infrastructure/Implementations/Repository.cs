using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OnlineVoting.Domain.UseCases;
using OnlineVoting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly VotingContext _context;
        protected readonly DbSet<T> _dbSet;


        //_dbSet = _context.votes;
        public Repository(VotingContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await Task.FromResult(entity);

        }

        public void DeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) { query = query.AsNoTracking(); }
            if (include != null) { query = include(query); }
            if (filter != null) { query = query.Where(filter); }
            if (orderBy != null) { return orderBy(query).ToList(); }
            return query.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public T GetByIdAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) { query = query.AsNoTracking(); }
            if (include != null) { query = include(query); }
            if (filter != null) { query = query.Where(filter); }
            if (orderBy != null) { return orderBy(query).FirstOrDefault(); }
            return query.FirstOrDefault();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }
    }
}
