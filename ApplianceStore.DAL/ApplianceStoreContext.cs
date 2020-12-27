using ApplianceStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace ApplianceStore.DAL
{
    public class ApplianceStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supply> Supplies { get; set; }

        public ApplianceStoreContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var product1 = new Product
            {
                Id = 1,
                Title = "title1",
                CountInStock = 10,
                Description = "descr1",
                IsAvailable = true,
                Manufacturer = "manufacturer1",
                Photo = "",
                Price = 12.5m
            };
            var product2 = new Product
            {
                Id = 2,
                Title = "title2",
                CountInStock = 12,
                Description = "descr2",
                IsAvailable = true,
                Manufacturer = "manufacturer2",
                Photo = "",
                Price = 245
            };

            modelBuilder.Entity<Product>().HasData(product1, product2);
            modelBuilder.Entity<Sale>().HasData
            (
                new Sale 
                { 
                    Id = 1, 
                    Count = 1,
                    Date = DateTime.Now,
                    Discount = 11,
                    ProductId = product1.Id
                },
                new Sale
                {
                    Id = 2,
                    Count = 12,
                    Date = DateTime.Now,
                    Discount = 1,
                    ProductId = product2.Id
                }
            );

            modelBuilder.Entity<Supply>().HasData
            (
                new Supply
                {
                    Id = 1,
                    Count = 1,
                    Date = DateTime.Now,
                    ProductId = product1.Id,
                    Supplier = "supplier1"
                },
                new Supply
                {
                    Id = 2,
                    Count = 12,
                    Date = DateTime.Now,
                    Supplier = "supplier1",
                    ProductId = product2.Id
                }
            );
        }
    }
}
