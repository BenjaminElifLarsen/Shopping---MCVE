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

        protected override void OnConfiguring(DbContextOptionsBuilder options) //used for the cli, need to check if it is only called by the parameterless ctor.
            => options.UseSqlServer($"Server=(localdb)\\MSSQLLocalDB;Database=Shoping;Trusted_Connection=True;MultipleActiveResultSets=true"); //options.UseSqlite($"Data Source=ShoppingLite");

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeePermission>()
                .HasKey(ep => new { ep.EmployeeId, ep.PermissionId });

            builder.Entity<OfferProductType>()
                .HasKey(op => new { op.OfferId, op.ProductTypeId});
        }


    }
}
