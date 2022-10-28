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
                    Name = "Marvel's Civil War",
                    Image = "https://salt.tikicdn.com/cache/750x750/ts/product/9e/b3/41/0c06634308a72a8a86cacfcde61db50e.jpg.webp",
                    Price = 12,
                    Description = "Iron Man and Captain America: two core members of the Avengers, the world’s greatest super hero team. When a tragic battle blows a hole in the city of Stamford, killing hundreds of people, the U.S. government demands that all super heroes unmask and register their powers. To Tony Stark–Iron Man–it’s a regrettable but necessary step. To Captain America, it’s an unbearable assault on civil liberties.",
                    Stock = 512,

                },
                new Book
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "One Pice",
                    Image = "https://salt.tikicdn.com/cache/750x750/ts/product/0e/0d/d0/6984eafe17135038efa10f7a567a06f3.jpg.webp",
                    Price = 12,
                    Description = "The main characters are already on the dome, Luffy's group confronts Kaido & Big Mom. In front of the strongest alliance in the world, is there any miracle to help them win? What future will open up for the warriors after this extreme battle?",
                    Stock = 512,

                },
                new Book
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Naruto",
                    Image = "https://salt.tikicdn.com/cache/750x750/ts/product/12/4a/28/f70efa285c1dd534dcf196d79f1ffe11.jpg.webp",
                    Price = 12,
                    Description = "Kakashi was shaken when he realized that Obito - his former teammate - was the masked man. But Naruto's words helped Kakashi rise again! With the motto \"Absolutely not letting teammates die\", Naruto's group has started to counterattack! However, the Ten-Tails eventually revived",
                    Stock = 512,

                     },
                new Book
                {
                    Id = 4,
                    CategoryId = 1,
                    Name = "Jujutsu kaisen",
                    Image = "https://salt.tikicdn.com/cache/750x750/ts/product/6b/98/82/8d6ef80eb54c5fb1e2d8f6e74de9ca6c.jpg.webp",
                    Price = 12,
                    Description = "The special-ranked spirit Hanami and the others had withdrawn from the spell school, but the fingers of Sukuna and the special-ranked \"Nine-Three-Grade\" were stolen. The Nine Realms acquires an entity and becomes a new threat. But Itadori and the others, unaware of that danger, still set out on a mission to destroy the \"Spirit that appeared at the door\"!?",
                    Stock = 512,

                },
                 new Book
                 {
                     Id = 5,
                     CategoryId = 2,
                     Name = "Harry Potter",
                     Image = "https://salt.tikicdn.com/cache/750x750/media/catalog/product/n/x/nxbtre_full_29292017_042903.u5430.d20170714.t090946.716950.jpg.webp",
                     Price = 20,
                     Description = "blalablablabbabababababababababbabababababababababbaba",
                     Stock = 10,
                 },
                 new Book
                 {
                     Id = 6,
                     CategoryId = 2,
                     Name = "A Game of Thrones",
                     Image = "https://salt.tikicdn.com/cache/750x750/ts/product/e9/f7/3e/8d76728ca02b8cc922f889827bd6ea51.jpg.webp",
                     Price = 30,
                     Description = "HBO’s hit series A GAME OF THRONES is based on George R R Martin’s internationally bestselling series A SONG OF ICE AND FIRE, the greatest fantasy epic of the modern age. A GAME OF THRONES is the first volume in the series.",
                     Stock = 421,
                 },
                 new Book
                 {
                     Id = 7,
                     CategoryId = 2,
                     Name = "The silence of the lambs",
                     Image = "https://salt.tikicdn.com/cache/750x750/media/catalog/product/t/h/the-silence-of-the-lambs.jpg.webp",
                     Price = 30,
                     Description = "As part of the search for a serial murderer nicknames \"Buffalo Bill,\" FBI trainee Clarice Starling is given an assignment. She must visit a man confined to a high-security facility for the criminally insane and interview him.",
                     Stock = 235,
                 },
                 new Book
                 {
                     Id = 8,
                     CategoryId = 2,
                     Name = "Sherlock Holmes - The Red Tower",
                     Image = "https://salt.tikicdn.com/cache/750x750/ts/product/af/81/cf/97eaacaddcaa94d8f00c1a148010deaa.jpg.webp",
                     Price = 30,
                     Description = "blalablablabbabababababababababbabababababababababbaba",
                     Stock = 123,
                 },
                  new Book
                  {
                      Id = 9,
                      CategoryId = 3,
                      Name = "English Grammar Explanation",
                      Image = "https://salt.tikicdn.com/cache/750x750/ts/product/e1/04/31/7763d9035552760f627c34acfec0e12f.jpg.webp",
                      Price = 10,
                      Description = "English Grammar synthesizes important grammar topics that students need to master. Grammar topics are presented clearly and in detail. After each grammar topic, there are exercises & answers to help students consolidate what they have learned, and at the same time check their results.",
                      Stock = 135,
                  },
                   new Book
                   {
                       Id = 10,
                       CategoryId = 3,
                       Name = "Self-study 2000 English Vocabulary",
                       Image = "https://salt.tikicdn.com/cache/750x750/ts/product/d5/53/0e/fc00028419754638dd5b250abbcb0de7.jpg.webp",
                       Price = 10,
                       Description = "Listening comprehension is one of the skills that requires concentration and practice of learners. Practice listening to English vocabulary by topic will provide exercises with advanced level, which is a useful document for those who want to improve their listening comprehension through learning vocabulary.",
                       Stock = 146,
                   },
                    new Book
                    {
                        Id = 11,
                        CategoryId = 3,
                        Name = "Practice Critical Thinking",
                        Image = "https://salt.tikicdn.com/cache/750x750/ts/product/22/cb/a9/524a27dcd45e8a13ae6eecb3dfacba7c.jpg.webp",
                        Price = 10,
                        Description = "This book will discuss about critical thinking and also help you to improve it",
                        Stock = 131,
                    },
                     new Book
                     {
                         Id = 12,
                         CategoryId = 3,
                         Name = "Why is sex fun ?",
                         Image = "https://salt.tikicdn.com/cache/750x750/ts/product/81/3d/4e/4d4a4ca625cb71e39c5a83bb764c3fe1.jpg.webp",
                         Price = 50,
                         Description = "Everyone thinks about sex. However, we rarely notice how sex in humans differs from the reproductive habits of other species. In Why Is Sex Fun?",
                         Stock = 846,
                     }

            );
        }
    }
}
