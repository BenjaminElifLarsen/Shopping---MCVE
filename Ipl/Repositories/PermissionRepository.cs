using Dal.Contracts;
using Dal.Models;
using Ipl.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class PermissionRepository : IPermissionRepository
    {
        private readonly ShopDbContext _shopDbContext;
        public PermissionRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public Task<IEnumerable<Permission>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public void Create(Permission permission)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> GetByIdAsyncWithRelationships(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Permission permission)
        {
            throw new NotImplementedException();
        }

        public void Update(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}
