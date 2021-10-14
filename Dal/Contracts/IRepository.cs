using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Contracts
{
    public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        public Task<IEnumerable<TEntity>> AllAsync();
        public Task<IEnumerable<TEntity>> FetchManyByQueryObjectAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<TEntity> FetchSingleOrDefaultByQueryObjectAsync(Expression<Func<TEntity, bool>> predicate);

        public void Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
