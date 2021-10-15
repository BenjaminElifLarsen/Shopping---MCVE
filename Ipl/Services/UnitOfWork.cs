﻿using Dal.Contracts;
using Dal.Models;
using Ipl.Databases;
using Ipl.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _context;

        public UnitOfWork(ShopDbContext shopDbContext)
        {
            _context = shopDbContext;
            CategoryRepository = new CategoryRepository(_context);
            EmployeeRepository = new EmployeeRepository(_context);
            PermissionRepository = new PermissionRepository(_context);
            ProductTypeRepository = new ProductTypeRepository(_context);
            OfferRepository = new OfferRepository(_context);
        }

        public ICategoryRepository CategoryRepository { get; }

        public IEmployeeRepository EmployeeRepository { get; }

        public IPermissionRepository PermissionRepository { get; }

        public IProductTypeRepository ProductTypeRepository { get; }

        public IOfferRepository OfferRepository { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            var ct = _context.ChangeTracker;
            foreach(var e in ct.Entries())
            {
                Console.WriteLine(e.Entity.GetType().Name + " : " +e.State);
            }
            return _context.SaveChangesAsync();
        }
    }
}
