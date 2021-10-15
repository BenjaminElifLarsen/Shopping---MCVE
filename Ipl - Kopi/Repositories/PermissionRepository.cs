using Dal.Contracts;
using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class PermissionRepository : IPermissionRepository
    {
        private Repository<Permission> _repository;

        public PermissionRepository(Repository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Permission>> AllAsync()
        {
            return await _repository.AllAsync();
        }

        public void Create(Permission permission)
        {
            _repository.Create(permission);
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await _repository.FetchSingleOrDefaultByQueryObjectAsync(p => p.PermissionId == id);
        }

        public Task<Permission> GetByIdAsyncWithRelationships(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Permission permission)
        {
            _repository.Delete(permission);
        }

        public void Update(Permission permission)
        {
            _repository.Update(permission);
        }
    }
}
