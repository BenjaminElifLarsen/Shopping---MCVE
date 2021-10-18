using Dal.Contracts;
using Dal.Models;
using Ipl.Repositories;
using Ipl.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new Ipl.Databases.ShopDbContext()))
            {
                Category tools = new("Tools");
                ProductType p = new("Hammer", 25, tools);
                Ware w1 = new("S1", p, new("Floor"));
                Ware w2 = new("S2", p, new("Floor"));
                Ware w3 = new("S3", p, new("Floor"));
                Ware w4 = new("S4", p, new("Floor"));
                Ware w5 = new("S5", p, new("Floor"));
                p.AddWare(w1);
                p.AddWare(w2);
                p.AddWare(w3);
                p.AddWare(w4);
                p.AddWare(w5);

                unitOfWork.ProductTypeRepository.Create(p);

                int alwaysThere = 1;
                int willBeDeleted = 2;

                ProductType selected1 = unitOfWork.ProductTypeRepository.GetByIdAsync(alwaysThere).Result;
                ProductType selected2 = unitOfWork.ProductTypeRepository.GetByIdAsyncWithRelationships(willBeDeleted).Result;
                var done = unitOfWork.SaveChangesAsync().Result;
                Console.WriteLine(done);
            };
        }
    }
}
