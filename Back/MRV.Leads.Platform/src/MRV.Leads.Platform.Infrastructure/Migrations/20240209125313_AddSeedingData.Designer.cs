﻿// <auto-generated />
using System;
using MRV.Leads.Platform.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MRV.Leads.Platform.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240209125313_AddSeedingData")]
    partial class AddSeedingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MRV.Leads.Platform.Domain.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("be9ac010-2695-47ef-9e94-fa308b7fe030"),
                            Email = "user1@example.com",
                            FullName = "Contact One",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            Id = new Guid("e7457cb1-e53f-4666-ad3b-0fb702812406"),
                            Email = "user2@example.com",
                            FullName = "Contact Two",
                            PhoneNumber = "0987654321"
                        },
                        new
                        {
                            Id = new Guid("aed071d5-f101-4787-9022-56c98125353d"),
                            Email = "user3@example.com",
                            FullName = "Contact Three",
                            PhoneNumber = "1020304050"
                        },
                        new
                        {
                            Id = new Guid("7f814c45-0768-43e5-ae9a-f261a3e6c6aa"),
                            Email = "user4@example.com",
                            FullName = "Contact Four",
                            PhoneNumber = "5040302010"
                        });
                });

            modelBuilder.Entity("MRV.Leads.Platform.Domain.Entities.Intent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Intents");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a136e6c3-2811-49d1-a650-afc0a83a257e"),
                            Active = true,
                            Category = 1,
                            ContactId = new Guid("be9ac010-2695-47ef-9e94-fa308b7fe030"),
                            CreatedDate = new DateTime(2024, 2, 9, 12, 53, 13, 192, DateTimeKind.Utc).AddTicks(491),
                            Description = "Initial intent",
                            Price = 99.99m,
                            Status = 0,
                            Suburb = "Yandera 2574"
                        },
                        new
                        {
                            Id = new Guid("9529e94d-da85-4808-822e-c0b3f8610749"),
                            Active = true,
                            Category = 2,
                            ContactId = new Guid("e7457cb1-e53f-4666-ad3b-0fb702812406"),
                            CreatedDate = new DateTime(2024, 2, 9, 12, 53, 13, 192, DateTimeKind.Utc).AddTicks(501),
                            Description = "Second intent",
                            Price = 99.99m,
                            Status = 0,
                            Suburb = "Woolooware 2230"
                        },
                        new
                        {
                            Id = new Guid("a126cd6c-c48e-47fe-9621-23fc85ccdd5e"),
                            Active = true,
                            Category = 4,
                            ContactId = new Guid("aed071d5-f101-4787-9022-56c98125353d"),
                            CreatedDate = new DateTime(2024, 2, 9, 12, 53, 13, 192, DateTimeKind.Utc).AddTicks(506),
                            Description = "Thirty intent",
                            Price = 699.99m,
                            Status = 1,
                            Suburb = "Caramar 6031"
                        },
                        new
                        {
                            Id = new Guid("f7d89403-014b-4b29-9623-916627b7d78d"),
                            Active = true,
                            Category = 3,
                            ContactId = new Guid("7f814c45-0768-43e5-ae9a-f261a3e6c6aa"),
                            CreatedDate = new DateTime(2024, 2, 9, 12, 53, 13, 192, DateTimeKind.Utc).AddTicks(523),
                            Description = "Fourthy intent",
                            Price = 499.99m,
                            Status = 1,
                            Suburb = "Quinss Rocks 6030"
                        });
                });

            modelBuilder.Entity("MRV.Leads.Platform.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("26e15674-0e3a-4115-813d-2fecd6b5042a"),
                            Active = false,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user1@example.com",
                            Login = "user1",
                            PasswordHash = "SomeHashedPassword"
                        },
                        new
                        {
                            Id = new Guid("0609c34b-e9bf-4de5-8b84-71374f785840"),
                            Active = false,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user2@example.com",
                            Login = "user2",
                            PasswordHash = "SomeHashedPassword"
                        });
                });

            modelBuilder.Entity("MRV.Leads.Platform.Domain.Entities.Intent", b =>
                {
                    b.HasOne("MRV.Leads.Platform.Domain.Entities.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
