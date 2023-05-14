﻿// <auto-generated />
using System;
using Labb4API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb4API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230511180155_nani")]
    partial class nani
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.Property<int>("InterestsInterestID")
                        .HasColumnType("int");

                    b.Property<int>("PersonsPersonID")
                        .HasColumnType("int");

                    b.HasKey("InterestsInterestID", "PersonsPersonID");

                    b.HasIndex("PersonsPersonID");

                    b.ToTable("InterestPerson");
                });

            modelBuilder.Entity("Labb4Models.Interest", b =>
                {
                    b.Property<int>("InterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InterestID");

                    b.ToTable("interests");

                    b.HasData(
                        new
                        {
                            InterestID = 1,
                            Description = "Programming with C#",
                            Title = "Programming"
                        },
                        new
                        {
                            InterestID = 2,
                            Description = "Doing sick flips",
                            Title = "Skateboarding"
                        },
                        new
                        {
                            InterestID = 3,
                            Description = "Getting gains",
                            Title = "Lifting"
                        });
                });

            modelBuilder.Entity("Labb4Models.Link", b =>
                {
                    b.Property<int>("LinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkID"));

                    b.Property<int>("InterestID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkID");

                    b.HasIndex("InterestID");

                    b.HasIndex("PersonID");

                    b.ToTable("links");

                    b.HasData(
                        new
                        {
                            LinkID = 1,
                            InterestID = 2,
                            PersonID = 1,
                            URL = "https://www.youtube.com"
                        },
                        new
                        {
                            LinkID = 2,
                            InterestID = 2,
                            PersonID = 2,
                            URL = "https://www.reddit.com"
                        },
                        new
                        {
                            LinkID = 3,
                            InterestID = 1,
                            PersonID = 3,
                            URL = "https://www.notion.com"
                        });
                });

            modelBuilder.Entity("Labb4Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("PersonID");

                    b.ToTable("persons");

                    b.HasData(
                        new
                        {
                            PersonID = 1,
                            Age = 30,
                            DateOfBirth = new DateTime(1990, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sana",
                            LastName = "Kolq",
                            Phone = "1234561337"
                        },
                        new
                        {
                            PersonID = 2,
                            Age = 33,
                            DateOfBirth = new DateTime(1987, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Saibot",
                            LastName = "Kolq",
                            Phone = "57678811"
                        },
                        new
                        {
                            PersonID = 3,
                            Age = 40,
                            DateOfBirth = new DateTime(1978, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Radier",
                            LastName = "Qolk",
                            Phone = "52266004"
                        });
                });

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.HasOne("Labb4Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsInterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb4Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsPersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labb4Models.Link", b =>
                {
                    b.HasOne("Labb4Models.Interest", "LinkInterest")
                        .WithMany("Links")
                        .HasForeignKey("InterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb4Models.Person", "LinkPerson")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkInterest");

                    b.Navigation("LinkPerson");
                });

            modelBuilder.Entity("Labb4Models.Interest", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
