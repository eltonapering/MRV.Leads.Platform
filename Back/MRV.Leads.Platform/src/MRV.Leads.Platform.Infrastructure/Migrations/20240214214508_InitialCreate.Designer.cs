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
    [Migration("20240214214508_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<string>("FirstName")
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
                            Id = new Guid("7e2273c4-f9c4-49e2-8da5-18d19367a552"),
                            Email = "billbrady@example.com",
                            FirstName = "Bill",
                            FullName = "Bill Brady",
                            PhoneNumber = "1234567890"
                        },
                        new
                        {
                            Id = new Guid("6b2ca483-8c5a-4b09-9be2-0afe75030309"),
                            Email = "craigflynn@example.com",
                            FirstName = "Craig",
                            FullName = "Craig Flynn",
                            PhoneNumber = "0987654321"
                        },
                        new
                        {
                            Id = new Guid("320c584f-ead4-4ff6-976f-6ffa0aa3d1b8"),
                            Email = "peteedwards@example.com",
                            FirstName = "Pete",
                            FullName = "Pete Edwards",
                            PhoneNumber = "1020304050"
                        },
                        new
                        {
                            Id = new Guid("ab6fc60c-d40d-49b9-9369-0b8843f3612b"),
                            Email = "chrissanderson@example.com",
                            FirstName = "Chris",
                            FullName = "Chris Sanderson",
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
                            Id = new Guid("c0ac40ed-1147-44cf-9f30-cf45e846a2e6"),
                            Active = true,
                            Category = 1,
                            ContactId = new Guid("7e2273c4-f9c4-49e2-8da5-18d19367a552"),
                            CreatedDate = new DateTime(2024, 2, 14, 21, 45, 7, 243, DateTimeKind.Utc).AddTicks(1248),
                            Description = "Need to paint 2 aluminium windows and a siding glass door",
                            Price = 99.99m,
                            Status = 0,
                            Suburb = "Yandera 2574"
                        },
                        new
                        {
                            Id = new Guid("15942722-a123-4cc7-8128-3284891ae5f2"),
                            Active = true,
                            Category = 2,
                            ContactId = new Guid("6b2ca483-8c5a-4b09-9be2-0afe75030309"),
                            CreatedDate = new DateTime(2024, 2, 14, 21, 45, 7, 243, DateTimeKind.Utc).AddTicks(1281),
                            Description = "Internal wall 3 colours",
                            Price = 99.99m,
                            Status = 0,
                            Suburb = "Woolooware 2230"
                        },
                        new
                        {
                            Id = new Guid("6810c405-14af-49cb-9649-25e638bbbb5f"),
                            Active = true,
                            Category = 4,
                            ContactId = new Guid("320c584f-ead4-4ff6-976f-6ffa0aa3d1b8"),
                            CreatedDate = new DateTime(2024, 2, 14, 21, 45, 7, 243, DateTimeKind.Utc).AddTicks(1286),
                            Description = "Plastes exposed brick wall (see photos), square off 2 archways (see photos), and expand pantry (see photos) ",
                            Price = 699.99m,
                            Status = 1,
                            Suburb = "Caramar 6031"
                        },
                        new
                        {
                            Id = new Guid("a12574d3-c804-46da-a200-9520ac783725"),
                            Active = true,
                            Category = 3,
                            ContactId = new Guid("ab6fc60c-d40d-49b9-9369-0b8843f3612b"),
                            CreatedDate = new DateTime(2024, 2, 14, 21, 45, 7, 243, DateTimeKind.Utc).AddTicks(1291),
                            Description = "There is a two story building at the front of the main house that´s about 10x5 thatwould like to convert into self contained living area ",
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
                            Id = new Guid("5d70a4ef-659f-44d0-b7e6-dae24846401d"),
                            Active = false,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user1@example.com",
                            Login = "user1",
                            PasswordHash = "SomeHashedPassword"
                        },
                        new
                        {
                            Id = new Guid("99061391-89fc-4339-bcca-c04759c9d657"),
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