using Dal.Contracts;
using Dal.Models;
using Ipl.Databases;
using Ipl.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ShopDbContext _context;

        public UnitOfWork(ShopDbContext shopDbContext)
        {
            _context = shopDbContext;
            ProductTypeRepository = new ProductTypeRepository(_context);
        }

        public IProductTypeRepository ProductTypeRepository { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            var ct = _context.ChangeTracker;
            foreach(var e in ct.Entries())
            {
                Console.Write(e.Entity.GetType().Name + " : " +e.State + " Id : ");
                switch (e.Entity)
                {
                    case ProductType p:
                        Console.Write(p.ProductTypeId);
                        break;
                    case Ware p:
                        Console.Write(p.WareId);
                        break;
                    case Category p:
                        Console.Write(p.CategoryId);
                        break;
                }
                Console.WriteLine();
            }
            return _context.SaveChangesAsync();
        }
    }
}
