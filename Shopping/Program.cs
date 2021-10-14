using Dal.Models;
using Ipl.Services;
using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            using (var unitOfWork = new UnitOfWork(new Ipl.Databases.ShopDbContext()))
            {
                unitOfWork.CategoryRepository.Create(new Category(""));


                var done = unitOfWork.SaveChangesAsync().Result;
            };
        }
    }
}
