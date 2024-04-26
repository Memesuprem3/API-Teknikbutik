using API_Teknikbutiken_Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace API_Teknikbutik.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }

        //Tables
        public DbSet<Product> Products{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Order> Orders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Test Data Product
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Iphone 13",
                Price = 8500.00m,
                Category = Category.Phone
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductName = "Samsung S10",
                Price = 3799.00m,
                Category = Category.Phone
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductName = "Asus RS6",
                Price = 7988.00m,
                Category = Category.Computer
            });

            //Test Data Customer
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Christian",
                LastName = "Rapp",
                Email = "Christianrapp2@outlook.com",
                Address = "Stenhuggerivägen 55",
                Phone = "0709909755"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Wilma",
                LastName = "Rogersdotter",
                Email = "WilmaR@gmail.com",
                Address = "Stenhuggerivägen 55",
                Phone = "078543154"
            });

            //Test Data Order
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderPlace = new DateTime(2021, 06, 22)
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 2,
                CustomerId = 2,
                OrderPlace = new DateTime(2023, 07, 13)
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 3,
                CustomerId = 2,
                OrderPlace = new DateTime(2024, 09, 11)
            });
        }
    }

}
