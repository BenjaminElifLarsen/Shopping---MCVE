﻿using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal.Contracts
{
    public interface IPermissionRepository
    {
        public Task<IEnumerable<Permission>> AllAsync();
        public Task<Permission> GetByIdAsync(int id);
        public Task<Permission> GetByIdAsyncWithRelationships(int id);
        public void Create(Permission permission);
        public void Update(Permission permission);
        public void Remove(Permission permission);
    }
}
