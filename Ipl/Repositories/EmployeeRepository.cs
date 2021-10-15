﻿using Dal.Contracts;
using Dal.Models;
using Ipl.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Repositories
{
    class EmployeeRepository : IEmployeeRepository
    {
        private readonly ShopDbContext _shopDbContext;
        public EmployeeRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public Task<IEnumerable<Employee>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public void Create(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsyncWithRelationships(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
