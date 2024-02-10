using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MRV.Leads.Platform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intents_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("462547c5-3d29-4d46-89ab-0bf46f510782"), "user4@example.com", "Contact Four", "5040302010" },
                    { new Guid("c1c6d0c4-ef52-48c7-bc2f-28958ffef95e"), "user2@example.com", "Contact Two", "0987654321" },
                    { new Guid("c5457100-13dd-4462-8352-8c2a10e0e89b"), "user3@example.com", "Contact Three", "1020304050" },
                    { new Guid("e4ac97f0-9c7b-4b0f-bacc-694f4344f5c1"), "user1@example.com", "Contact One", "1234567890" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedDate", "Email", "Login", "PasswordHash" },
                values: new object[,]
                {
                    { new Guid("2c85deda-d510-4c37-9c31-fc691bb7d9d6"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "user2", "SomeHashedPassword" },
                    { new Guid("42a11b3e-5d94-423f-bec0-c9c034fdb8f4"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "user1", "SomeHashedPassword" }
                });

            migrationBuilder.InsertData(
                table: "Intents",
                columns: new[] { "Id", "Active", "Category", "ContactId", "CreatedDate", "Description", "Price", "Status", "Suburb" },
                values: new object[,]
                {
                    { new Guid("4fc22a04-06d8-4e89-a9b0-380de22b1e39"), true, 4, new Guid("c5457100-13dd-4462-8352-8c2a10e0e89b"), new DateTime(2024, 2, 9, 12, 52, 53, 562, DateTimeKind.Utc).AddTicks(3064), "Thirty intent", 699.99m, 1, "Caramar 6031" },
                    { new Guid("70b81aad-be1b-492f-9c7e-5684af79ae01"), true, 3, new Guid("462547c5-3d29-4d46-89ab-0bf46f510782"), new DateTime(2024, 2, 9, 12, 52, 53, 562, DateTimeKind.Utc).AddTicks(3068), "Fourthy intent", 499.99m, 1, "Quinss Rocks 6030" },
                    { new Guid("e8d5046a-87ea-4268-899d-6092151354f4"), true, 1, new Guid("e4ac97f0-9c7b-4b0f-bacc-694f4344f5c1"), new DateTime(2024, 2, 9, 12, 52, 53, 562, DateTimeKind.Utc).AddTicks(3053), "Initial intent", 99.99m, 0, "Yandera 2574" },
                    { new Guid("f67e0a23-b99f-4c1b-89f0-4f65c83eff26"), true, 2, new Guid("c1c6d0c4-ef52-48c7-bc2f-28958ffef95e"), new DateTime(2024, 2, 9, 12, 52, 53, 562, DateTimeKind.Utc).AddTicks(3060), "Second intent", 99.99m, 0, "Woolooware 2230" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intents_ContactId",
                table: "Intents",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
