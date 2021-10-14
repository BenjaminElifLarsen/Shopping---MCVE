﻿// <auto-generated />
using System;
using Ipl.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ipl.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Dal.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Dal.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Dal.Models.JoiningTables.EmployeePermission", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PermissionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployeeId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("EmployeePermission");
                });

            modelBuilder.Entity("Dal.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Dal.Models.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Dal.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Prise")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductTypeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Dal.Models.Ware", b =>
                {
                    b.Property<int>("WareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("WareId");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Ware");
                });

            modelBuilder.Entity("Dal.Models.JoiningTables.EmployeePermission", b =>
                {
                    b.HasOne("Dal.Models.Employee", "Employee")
                        .WithMany("EmployeePermissions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Models.Permission", "Permission")
                        .WithMany("EmployeePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Dal.Models.ProductType", b =>
                {
                    b.HasOne("Dal.Models.Category", null)
                        .WithMany("ProductTypes")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Dal.Models.Ware", b =>
                {
                    b.HasOne("Dal.Models.Location", "Location")
                        .WithOne("Ware")
                        .HasForeignKey("Dal.Models.Ware", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dal.Models.ProductType", "ProductType")
                        .WithMany("Wares")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Dal.Models.Category", b =>
                {
                    b.Navigation("ProductTypes");
                });

            modelBuilder.Entity("Dal.Models.Employee", b =>
                {
                    b.Navigation("EmployeePermissions");
                });

            modelBuilder.Entity("Dal.Models.Location", b =>
                {
                    b.Navigation("Ware");
                });

            modelBuilder.Entity("Dal.Models.Permission", b =>
                {
                    b.Navigation("EmployeePermissions");
                });

            modelBuilder.Entity("Dal.Models.ProductType", b =>
                {
                    b.Navigation("Wares");
                });
#pragma warning restore 612, 618
        }
    }
}
