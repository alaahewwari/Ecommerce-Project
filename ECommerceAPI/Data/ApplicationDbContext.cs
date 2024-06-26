﻿using ECommerceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ECommerceAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<User,Role,long>(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
        public DbSet<CategoryAttributeValue> CategoryAttributeValues { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customers");
            SeedRoles(modelBuilder);
            SeedBrands(modelBuilder);
            SeedCategories(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                  new Role
                  {
                      Id = 1,
                      Name = "Admin"
                  },
                  new Role
                  {
                      Id = 2,
                      Name = "Store Manager"
                  }
            );
        }
        private static void SeedCategories(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Electronics"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Clothing"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Books"
                    }
         );
        }
        private static void SeedBrands(ModelBuilder builder)
        {
            builder.Entity<Brand>().HasData(
                   new Brand
                   {
                       Id = 1,
                       Name = "Apple"
                   },
                   new Brand
                   {
                       Id = 2,
                       Name = "Samsung"
                   },
                   new Brand
                   {
                       Id = 3,
                       Name = "Nike"
                   }
                );
        }
    }
}
