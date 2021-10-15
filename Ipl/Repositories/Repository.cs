using Dal.Contracts;
using Ipl.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly ShopDbContext _context;
        private readonly DbSet<TEntity> _entities;

        public Repository(ShopDbContext shopDbContext) // These should not save, only the UnitOfWork should permit saving.
        {
            _context = shopDbContext;
            _entities = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await _entities.ToArrayAsync();
        }

        public void Create(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> FetchManyByQueryObjectAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.Where(predicate).ToArrayAsync();
        }

        public async Task<IEnumerable<TEntity>> FetchManyByQueryObjectAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _entities.AsQueryable();

            query = includes.Aggregate(query,
                      (current, include) => current.Include(include));

            return await query.Where(predicate).ToArrayAsync();
        }

        public async Task<TEntity> FetchSingleOrDefaultByQueryObjectAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FetchSingleOrDefaultByQueryObjectAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _entities.AsQueryable();

            query = includes.Aggregate(query,
                      (current, include) => current.Include(include));

            return await query.SingleOrDefaultAsync(predicate);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }
    }
}
