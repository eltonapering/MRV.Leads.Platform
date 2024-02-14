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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Id", "Email", "FirstName", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("320c584f-ead4-4ff6-976f-6ffa0aa3d1b8"), "peteedwards@example.com", "Pete", "Pete Edwards", "1020304050" },
                    { new Guid("6b2ca483-8c5a-4b09-9be2-0afe75030309"), "craigflynn@example.com", "Craig", "Craig Flynn", "0987654321" },
                    { new Guid("7e2273c4-f9c4-49e2-8da5-18d19367a552"), "billbrady@example.com", "Bill", "Bill Brady", "1234567890" },
                    { new Guid("ab6fc60c-d40d-49b9-9369-0b8843f3612b"), "chrissanderson@example.com", "Chris", "Chris Sanderson", "5040302010" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedDate", "Email", "Login", "PasswordHash" },
                values: new object[,]
                {
                    { new Guid("5d70a4ef-659f-44d0-b7e6-dae24846401d"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "user1", "SomeHashedPassword" },
                    { new Guid("99061391-89fc-4339-bcca-c04759c9d657"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "user2", "SomeHashedPassword" }
                });

            migrationBuilder.InsertData(
                table: "Intents",
                columns: new[] { "Id", "Active", "Category", "ContactId", "CreatedDate", "Description", "Price", "Status", "Suburb" },
                values: new object[,]
                {
                    { new Guid("15942722-a123-4cc7-8128-3284891ae5f2"), true, 2, new Guid("6b2ca483-8c5a-4b09-9be2-0afe75030309"), new DateTime(2024, 2, 14, 21, 45, 7, 243, DateTimeKind.Utc).AddTicks(1281), "Internal wall 3 colours", 99.99m, 0, "Woolooware 2230" },
                    { new Guid("6810c405-14af-49cb-9649-25e638bbbb5f"), true, 4, new Guid("320c584f-ead4-4ff6-976f-6ffa0aa3d1b8"), new DateTime(2024, 2, 14, 21, 45, 7, 243, DateTimeKind.Utc).AddTicks(1286), "Plastes exposed brick wall (see photos), square off 2 archways (see photos), and expand pantry (see photos) ", 699.99m, 1, "Caramar 6031" },
                    { new Guid("a12574d3-c804-46da-a200-9520ac783725"), true, 3, new Guid("ab6fc60c-d40d-49b9-9369-0b8843f3612b"), new DateTime(2024, 2, 14, 21, 45, 7, 243, DateTimeKind.Utc).AddTicks(1291), "There is a two story building at the front of the main house that´s about 10x5 thatwould like to convert into self contained living area ", 499.99m, 1, "Quinss Rocks 6030" },
                    { new Guid("c0ac40ed-1147-44cf-9f30-cf45e846a2e6"), true, 1, new Guid("7e2273c4-f9c4-49e2-8da5-18d19367a552"), new DateTime(2024, 2, 14, 21, 45, 7, 243, DateTimeKind.Utc).AddTicks(1248), "Need to paint 2 aluminium windows and a siding glass door", 99.99m, 0, "Yandera 2574" }
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
