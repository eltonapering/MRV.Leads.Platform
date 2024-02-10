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
                keyValue: new Guid("4fc22a04-06d8-4e89-a9b0-380de22b1e39"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("70b81aad-be1b-492f-9c7e-5684af79ae01"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("e8d5046a-87ea-4268-899d-6092151354f4"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("f67e0a23-b99f-4c1b-89f0-4f65c83eff26"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2c85deda-d510-4c37-9c31-fc691bb7d9d6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("42a11b3e-5d94-423f-bec0-c9c034fdb8f4"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("462547c5-3d29-4d46-89ab-0bf46f510782"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("c1c6d0c4-ef52-48c7-bc2f-28958ffef95e"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("c5457100-13dd-4462-8352-8c2a10e0e89b"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("e4ac97f0-9c7b-4b0f-bacc-694f4344f5c1"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("7f814c45-0768-43e5-ae9a-f261a3e6c6aa"), "user4@example.com", "Contact Four", "5040302010" },
                    { new Guid("aed071d5-f101-4787-9022-56c98125353d"), "user3@example.com", "Contact Three", "1020304050" },
                    { new Guid("be9ac010-2695-47ef-9e94-fa308b7fe030"), "user1@example.com", "Contact One", "1234567890" },
                    { new Guid("e7457cb1-e53f-4666-ad3b-0fb702812406"), "user2@example.com", "Contact Two", "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedDate", "Email", "Login", "PasswordHash" },
                values: new object[,]
                {
                    { new Guid("0609c34b-e9bf-4de5-8b84-71374f785840"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@example.com", "user2", "SomeHashedPassword" },
                    { new Guid("26e15674-0e3a-4115-813d-2fecd6b5042a"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", "user1", "SomeHashedPassword" }
                });

            migrationBuilder.InsertData(
                table: "Intents",
                columns: new[] { "Id", "Active", "Category", "ContactId", "CreatedDate", "Description", "Price", "Status", "Suburb" },
                values: new object[,]
                {
                    { new Guid("9529e94d-da85-4808-822e-c0b3f8610749"), true, 2, new Guid("e7457cb1-e53f-4666-ad3b-0fb702812406"), new DateTime(2024, 2, 9, 12, 53, 13, 192, DateTimeKind.Utc).AddTicks(501), "Second intent", 99.99m, 0, "Woolooware 2230" },
                    { new Guid("a126cd6c-c48e-47fe-9621-23fc85ccdd5e"), true, 4, new Guid("aed071d5-f101-4787-9022-56c98125353d"), new DateTime(2024, 2, 9, 12, 53, 13, 192, DateTimeKind.Utc).AddTicks(506), "Thirty intent", 699.99m, 1, "Caramar 6031" },
                    { new Guid("a136e6c3-2811-49d1-a650-afc0a83a257e"), true, 1, new Guid("be9ac010-2695-47ef-9e94-fa308b7fe030"), new DateTime(2024, 2, 9, 12, 53, 13, 192, DateTimeKind.Utc).AddTicks(491), "Initial intent", 99.99m, 0, "Yandera 2574" },
                    { new Guid("f7d89403-014b-4b29-9623-916627b7d78d"), true, 3, new Guid("7f814c45-0768-43e5-ae9a-f261a3e6c6aa"), new DateTime(2024, 2, 9, 12, 53, 13, 192, DateTimeKind.Utc).AddTicks(523), "Fourthy intent", 499.99m, 1, "Quinss Rocks 6030" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("9529e94d-da85-4808-822e-c0b3f8610749"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("a126cd6c-c48e-47fe-9621-23fc85ccdd5e"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("a136e6c3-2811-49d1-a650-afc0a83a257e"));

            migrationBuilder.DeleteData(
                table: "Intents",
                keyColumn: "Id",
                keyValue: new Guid("f7d89403-014b-4b29-9623-916627b7d78d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0609c34b-e9bf-4de5-8b84-71374f785840"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26e15674-0e3a-4115-813d-2fecd6b5042a"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("7f814c45-0768-43e5-ae9a-f261a3e6c6aa"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("aed071d5-f101-4787-9022-56c98125353d"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("be9ac010-2695-47ef-9e94-fa308b7fe030"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("e7457cb1-e53f-4666-ad3b-0fb702812406"));

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
        }
    }
}
