using Dal.Models;
using Ipl.Services;
using System;
using System.Linq;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            using (var unitOfWork = new UnitOfWork(new Ipl.Databases.ShopDbContext()))
            {
                unitOfWork.CategoryRepository.Create(new("Foods"));
                unitOfWork.CategoryRepository.Create(new("Computers"));
                Category c = new Category("Liquids");
                unitOfWork.CategoryRepository.Create(c);
                unitOfWork.CategoryRepository.Create(new("Tools"));
                unitOfWork.CategoryRepository.Create(new("Atoms"));
                var done = unitOfWork.SaveChangesAsync().Result;

                foreach (CategoryRecord category in unitOfWork.CategoryRepository.AllAsync().Result.Select(c => new CategoryRecord { Id = c.CategoryId, Name = c.Name }))
                {
                    Console.WriteLine(category);
                }
                

                unitOfWork.CategoryRepository.Remove(c);
                done = unitOfWork.SaveChangesAsync().Result;

                Console.WriteLine("Removed: " + new CategoryRecord { Id = c.CategoryId, Name = c.Name });

                foreach (CategoryRecord category in unitOfWork.CategoryRepository.AllAsync().Result.Select(c => new CategoryRecord { Id = c.CategoryId, Name = c.Name }))
                {
                    Console.WriteLine(category);
                }

            };
        }

        public record CategoryRecord
        {
            public int Id { get; init; }
            public string Name { get; init; }
        }
    }
}
