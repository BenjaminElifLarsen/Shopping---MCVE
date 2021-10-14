﻿using Dal.Models;
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
            => options.UseSqlite($"Data Source=ShoppingLite");

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeePermission>()
                .HasKey(ep => new { ep.EmployeeId, ep.PermissionId });
        }


    }
}
