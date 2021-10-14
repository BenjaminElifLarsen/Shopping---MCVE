using Dal.Contracts;
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
            CategoryRepository = new CategoryRepository(new Repository<Category>(_context));
            EmployeeRepository = new EmployeeRepository(new Repository<Employee>(_context));
            PermissionRepository = new PermissionRepository(new Repository<Permission>(_context));
            ProductTypeRepository = new ProductTypeRepository(new Repository<ProductType>(_context));
            OfferRepository = new OfferRepository(new Repository<Offer>(_context));
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
            return _context.SaveChangesAsync();
        }
    }
}
