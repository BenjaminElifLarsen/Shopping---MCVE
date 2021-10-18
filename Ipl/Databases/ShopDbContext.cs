using Dal.Models;
using Dal.Models.JoiningTables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipl.Databases
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {

        }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server=(localdb)\\MSSQLLocalDB;Database=Shopping;Trusted_Connection=True;MultipleActiveResultSets=true"); //options.UseSqlite($"Data Source=ShoppingLite");

        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OfferProductType>()
                .HasKey(op => new { op.OfferId, op.ProductTypeId});

            builder.Entity<Category>().ToTable("TestCategories");
        }

        

    }
}
