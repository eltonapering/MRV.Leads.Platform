using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MRV.Leads.Platform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("15942722-a123-4cc7-8128-3284891ae5f2"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("6810c405-14af-49cb-9649-25e638bbbb5f"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("a12574d3-c804-46da-a200-9520ac783725"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("c0ac40ed-1147-44cf-9f30-cf45e846a2e6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5d70a4ef-659f-44d0-b7e6-dae24846401d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("99061391-89fc-4339-bcca-c04759c9d657"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("320c584f-ead4-4ff6-976f-6ffa0aa3d1b8"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("6b2ca483-8c5a-4b09-9be2-0afe75030309"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("7e2273c4-f9c4-49e2-8da5-18d19367a552"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("ab6fc60c-d40d-49b9-9369-0b8843f3612b"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("43846aea-f12b-4e48-89de-c5f6e9eb1795"), "chrissanderson@example.com", "Chris", "Chris Sanderson", "5040302010" },
                    { new Guid("6d4b1892-226b-48b3-abdd-68b24dadb2b7"), "billbrady@example.com", "Bill", "Bill Brady", "1234567890" },
                    { new Guid("e4005658-ddfe-415a-a880-3350af33aa6e"), "peteedwards@example.com", "Pete", "Pete Edwards", "1020304050" },
                    { new Guid("eb2ecc5a-eb33-4c0e-8883-319a010fa5ce"), "craigflynn@example.com", "Craig", "Craig Flynn", "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedDate", "Email", "Login", "PasswordHash" },
                values: new object[,]
                {
                    { new Guid("75294ebe-5813-468b-8d35-46879f6b6f3b"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "user1", "SomeHashedPassword" },
                    { new Guid("f6b279d1-0c84-43ba-acca-a44454a86c9e"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "user2", "SomeHashedPassword" }
                });

            migrationBuilder.InsertData(
                table: "Intents",
                columns: new[] { "Id", "Active", "Category", "ContactId", "CreatedDate", "Description", "Price", "Status", "Suburb" },
                values: new object[,]
                {
                    { new Guid("56696dc7-1dcb-453f-943d-e31b085ed99d"), true, 1, new Guid("6d4b1892-226b-48b3-abdd-68b24dadb2b7"), new DateTime(2024, 2, 14, 21, 45, 37, 83, DateTimeKind.Utc).AddTicks(1268), "Need to paint 2 aluminium windows and a siding glass door", 99.99m, 0, "Yandera 2574" },
                    { new Guid("5f0d2942-3038-48ec-8c9b-7659d7e0d605"), true, 2, new Guid("eb2ecc5a-eb33-4c0e-8883-319a010fa5ce"), new DateTime(2024, 2, 14, 21, 45, 37, 83, DateTimeKind.Utc).AddTicks(1281), "Internal wall 3 colours", 99.99m, 0, "Woolooware 2230" },
                    { new Guid("89d2a743-476a-434b-90ac-0b2c8f72921a"), true, 4, new Guid("e4005658-ddfe-415a-a880-3350af33aa6e"), new DateTime(2024, 2, 14, 21, 45, 37, 83, DateTimeKind.Utc).AddTicks(1287), "Plastes exposed brick wall (see photos), square off 2 archways (see photos), and expand pantry (see photos) ", 699.99m, 1, "Caramar 6031" },
                    { new Guid("f36cc420-2059-46a0-8589-0268ad192b8f"), true, 3, new Guid("43846aea-f12b-4e48-89de-c5f6e9eb1795"), new DateTime(2024, 2, 14, 21, 45, 37, 83, DateTimeKind.Utc).AddTicks(1292), "There is a two story building at the front of the main house that´s about 10x5 thatwould like to convert into self contained living area ", 499.99m, 1, "Quinss Rocks 6030" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("56696dc7-1dcb-453f-943d-e31b085ed99d"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("5f0d2942-3038-48ec-8c9b-7659d7e0d605"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("89d2a743-476a-434b-90ac-0b2c8f72921a"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("f36cc420-2059-46a0-8589-0268ad192b8f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75294ebe-5813-468b-8d35-46879f6b6f3b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f6b279d1-0c84-43ba-acca-a44454a86c9e"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("43846aea-f12b-4e48-89de-c5f6e9eb1795"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("6d4b1892-226b-48b3-abdd-68b24dadb2b7"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("e4005658-ddfe-415a-a880-3350af33aa6e"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("eb2ecc5a-eb33-4c0e-8883-319a010fa5ce"));

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
        }
    }
}
