using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderStock = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "A", "01b3293e-0540-4a4d-855b-97ffc207986a", "Admin", "Admin" },
                    { "B", "bcd6adb6-0ee3-4a4c-96fe-250d60daf9fa", "Customer", "Customer" },
                    { "C", "cbc23a67-3bb1-4869-ba90-9b46501ce931", "StoreOwner", "StoreOwner" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "c4b59a1c-389b-4064-91e0-8369d993754f", "admin@gmail.com", true, false, null, null, "admin@gmail.com", "AQAAAAEAACcQAAAAEGLpuYmPbGsXeSeJYkZgPfneswxLegFtt6YHh7uAIrD8OvnNwTyH9/Ug3/vr0S1PmQ==", null, false, "4bb3bc4e-4a54-45b8-8b49-046def84aa91", false, "admin@gmail.com" },
                    { "2", 0, "27464308-c594-4882-9f5f-e3f1cb9cd23e", "customer@gmail.com", true, false, null, null, "customer@gmail.com", "AQAAAAEAACcQAAAAEISf3Usvlm08ZDEDNYdN74w9lvL1RzBxZdQ+MqUMYZk2RC0mbjP1XLl3FOu6E6wOpg==", null, false, "650bdf3c-50b6-4663-b152-cfedb1bd2e1b", false, "customer@gmail.com" },
                    { "3", 0, "43ff9a08-d354-40ce-ba41-396a12f46357", "storeOwner@gmail.com", true, false, null, null, "storeOwner@gmail.com", "AQAAAAEAACcQAAAAEHkDPS8T091ZvRU97mhvsMa1+gcSUGK0/iGiccgDMo5LujK2j4PAyg2WyJwrhoaahQ==", null, false, "0e5f5a57-152d-46b9-8ca1-7f19e7cbefc8", false, "storeOwner@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Comic" },
                    { 2, "Novel" },
                    { 3, "Education" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "1", "A" },
                    { "2", "B" },
                    { "3", "C" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Iron Man and Captain America: two core members of the Avengers, the world’s greatest super hero team. When a tragic battle blows a hole in the city of Stamford, killing hundreds of people, the U.S. government demands that all super heroes unmask and register their powers. To Tony Stark–Iron Man–it’s a regrettable but necessary step. To Captain America, it’s an unbearable assault on civil liberties.", "https://salt.tikicdn.com/cache/750x750/ts/product/9e/b3/41/0c06634308a72a8a86cacfcde61db50e.jpg.webp", "Marvel's Civil War", 12, 512 },
                    { 2, 1, "The main characters are already on the dome, Luffy's group confronts Kaido & Big Mom. In front of the strongest alliance in the world, is there any miracle to help them win? What future will open up for the warriors after this extreme battle?", "https://salt.tikicdn.com/cache/750x750/ts/product/0e/0d/d0/6984eafe17135038efa10f7a567a06f3.jpg.webp", "One Pice", 12, 512 },
                    { 3, 1, "Kakashi was shaken when he realized that Obito - his former teammate - was the masked man. But Naruto's words helped Kakashi rise again! With the motto \"Absolutely not letting teammates die\", Naruto's group has started to counterattack! However, the Ten-Tails eventually revived", "https://salt.tikicdn.com/cache/750x750/ts/product/12/4a/28/f70efa285c1dd534dcf196d79f1ffe11.jpg.webp", "Naruto", 12, 512 },
                    { 4, 1, "The special-ranked spirit Hanami and the others had withdrawn from the spell school, but the fingers of Sukuna and the special-ranked \"Nine-Three-Grade\" were stolen. The Nine Realms acquires an entity and becomes a new threat. But Itadori and the others, unaware of that danger, still set out on a mission to destroy the \"Spirit that appeared at the door\"!?", "https://salt.tikicdn.com/cache/750x750/ts/product/6b/98/82/8d6ef80eb54c5fb1e2d8f6e74de9ca6c.jpg.webp", "Jujutsu kaisen", 12, 512 },
                    { 5, 2, "blalablablabbabababababababababbabababababababababbaba", "https://salt.tikicdn.com/cache/750x750/media/catalog/product/n/x/nxbtre_full_29292017_042903.u5430.d20170714.t090946.716950.jpg.webp", "Harry Potter", 20, 10 },
                    { 6, 2, "HBO’s hit series A GAME OF THRONES is based on George R R Martin’s internationally bestselling series A SONG OF ICE AND FIRE, the greatest fantasy epic of the modern age. A GAME OF THRONES is the first volume in the series.", "https://salt.tikicdn.com/cache/750x750/ts/product/e9/f7/3e/8d76728ca02b8cc922f889827bd6ea51.jpg.webp", "A Game of Thrones", 30, 421 },
                    { 7, 2, "As part of the search for a serial murderer nicknames \"Buffalo Bill,\" FBI trainee Clarice Starling is given an assignment. She must visit a man confined to a high-security facility for the criminally insane and interview him.", "https://salt.tikicdn.com/cache/750x750/media/catalog/product/t/h/the-silence-of-the-lambs.jpg.webp", "The silence of the lambs", 30, 235 },
                    { 8, 2, "blalablablabbabababababababababbabababababababababbaba", "https://salt.tikicdn.com/cache/750x750/ts/product/af/81/cf/97eaacaddcaa94d8f00c1a148010deaa.jpg.webp", "Sherlock Holmes - The Red Tower", 30, 123 },
                    { 9, 3, "English Grammar synthesizes important grammar topics that students need to master. Grammar topics are presented clearly and in detail. After each grammar topic, there are exercises & answers to help students consolidate what they have learned, and at the same time check their results.", "https://salt.tikicdn.com/cache/750x750/ts/product/e1/04/31/7763d9035552760f627c34acfec0e12f.jpg.webp", "English Grammar Explanation", 10, 135 },
                    { 10, 3, "Listening comprehension is one of the skills that requires concentration and practice of learners. Practice listening to English vocabulary by topic will provide exercises with advanced level, which is a useful document for those who want to improve their listening comprehension through learning vocabulary.", "https://salt.tikicdn.com/cache/750x750/ts/product/d5/53/0e/fc00028419754638dd5b250abbcb0de7.jpg.webp", "Self-study 2000 English Vocabulary", 10, 146 },
                    { 11, 3, "This book will discuss about critical thinking and also help you to improve it", "https://salt.tikicdn.com/cache/750x750/ts/product/22/cb/a9/524a27dcd45e8a13ae6eecb3dfacba7c.jpg.webp", "Practice Critical Thinking", 10, 131 },
                    { 12, 3, "Everyone thinks about sex. However, we rarely notice how sex in humans differs from the reproductive habits of other species. In Why Is Sex Fun?", "https://salt.tikicdn.com/cache/750x750/ts/product/81/3d/4e/4d4a4ca625cb71e39c5a83bb764c3fe1.jpg.webp", "Why is sex fun ?", 50, 846 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
