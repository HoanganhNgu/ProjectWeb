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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PopulateUniversity(builder);

            SeedBook(builder);
        }

        private void PopulateUniversity(ModelBuilder builder)
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

                },
                new Book
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Hary Potter and fuck your mom",
                    Image = "https://memehay.com/meme/20210816/bia-sach-harry-potter-va-cai-dit-con-me-may.jpg",
                    Price = 50,
                    Description = "blalablablab",

                },
                 new Book
                 {
                     Id = 3,
                     CategoryId = 3,
                     Name = "Hoan Rose",
                     Image = "https://i.ytimg.com/vi/EXH1CBjAhpo/maxresdefault.jpg",
                     Price = 50,
                     Description = "blalablablab",

                 }

            );
        }
    }
}
