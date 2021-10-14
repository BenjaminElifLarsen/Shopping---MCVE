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
        }

        public ICategoryRepository CategoryRepository { get; }

        public IEmployeeRepository EmployeeRepository { get; }

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
