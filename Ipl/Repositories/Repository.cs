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

        public Task<IEnumerable<TEntity>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FetchManyByQueryObjectAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FetchSingleOrDefaultByQueryObjectAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
