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
                Category tools = new("Tools");
                unitOfWork.CategoryRepository.Create(tools);
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
                done = unitOfWork.SaveChangesAsync().Result;

                Console.WriteLine($"Product Id: {p.ProductTypeId}, Type: {p.Type}, Price: {p.CurrentPrice()}, Category Name: {p.Category.Name}");
                foreach (var w in p.Wares)
                {
                    Console.WriteLine($"Ware Id: {w.WareId}, Serial Number: {w.SerialNumber}, Location Name: {w.Location.Name}");
                }

                Ware update = new(5, null, p, new("Shelf"));
                p.UpdateWare(update);
                p.RemoveWare(w3);

                unitOfWork.ProductTypeRepository.Update(p);

                Offer o = new("BUY BUY!!!!!", 25, "GIVE US YOUR MONEY!!!!", true);
                o.AddProductToOffer(p);
                unitOfWork.OfferRepository.Create(o);

                done = unitOfWork.SaveChangesAsync().Result;

                p = unitOfWork.ProductTypeRepository.GetByIdAsync(p.ProductTypeId).Result;

                Console.WriteLine($"Product Id: {p.ProductTypeId}, Type: {p.Type}, Price: {p.CurrentPrice()}, Category Name: {p.Category.Name}");
                foreach (var w in p.Wares)
                {
                    Console.WriteLine($"Ware Id: {w.WareId}, Serial Number: {w.SerialNumber}, Location Name: {w.Location.Name}");
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
