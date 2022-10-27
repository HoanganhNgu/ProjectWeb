using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Account> Accounts { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PopulateBook(builder);

            SeedBook(builder);

            SeedUser(builder);

            SeedRole(builder);

            SeedUserRole(builder);
        }

        private void SeedUser(ModelBuilder builder)
        {
            var admin = new IdentityUser
            {
                Id = "1",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                EmailConfirmed = true
            };
            var customer = new IdentityUser
            {
                Id = "2",
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                NormalizedUserName = "customer@gmail.com",
                EmailConfirmed = true
            };
            var storeOwner = new IdentityUser
            {
                Id = "3",
                UserName = "storeOwner@gmail.com",
                Email = "storeOwner@gmail.com",
                NormalizedUserName = "storeOwner@gmail.com",
                EmailConfirmed = true

            };

            var hasher = new PasswordHasher<IdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, "Ha123@");
            customer.PasswordHash = hasher.HashPassword(customer, "Ha123@");
            storeOwner.PasswordHash = hasher.HashPassword(storeOwner, "Ha123@");

            builder.Entity<IdentityUser>().HasData(admin, customer, storeOwner);
        }

        private void SeedRole(ModelBuilder builder)
        {

            var admin = new IdentityRole
            {
                Id = "A",
                Name = "Admin",
                NormalizedName = "Admin"
            };
            var customer = new IdentityRole
            {
                Id = "B",
                Name = "Customer",
                NormalizedName = "Customer"
            };
            var storeOwner = new IdentityRole
            {
                Id = "C",
                Name = "StoreOwner",
                NormalizedName = "StoreOwner"
            };

            builder.Entity<IdentityRole>().HasData(admin, customer, storeOwner);

        }

        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   UserId = "1",
                   RoleId = "A"
               },
               new IdentityUserRole<string>
               {
                   UserId = "2",
                   RoleId = "B"
               },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "C"
                }
            );
        }

        private void PopulateBook(ModelBuilder builder)
        {
            var Comic = new Category
            {
                Id = 1,
                Name = "Comic",

            };
            var Novel = new Category
            {
                Id = 2,
                Name = "Novel",

            };
            var Education = new Category
            {
                Id = 3,
                Name = "Education",

            };
            builder.Entity<Category>().HasData(Comic, Novel, Education);
        }
        private void SeedBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Conan",
                    Image = "http://pm1.narvii.com/6694/cda75d1728f061082c45dd929d482bd9fcd3d82d_00.jpg",
                    Price = 50,
                    Description = "blalablablab",
                    Stock = 30,

                },
                new Book
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Hary Potter and fuck your mom",
                    Image = "https://memehay.com/meme/20210816/bia-sach-harry-potter-va-cai-dit-con-me-may.jpg",
                    Price = 50,
                    Description = "blalablablab",
                    Stock = 30,

                },
                 new Book
                 {
                     Id = 3,
                     CategoryId = 3,
                     Name = "Hoan Rose",
                     Image = "https://i.ytimg.com/vi/EXH1CBjAhpo/maxresdefault.jpg",
                     Price = 50,
                     Description = "blalablablab",
                     Stock = 30,
                 }

            );
        }
    }
}
