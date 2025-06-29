﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeriesVault.Data;

#nullable disable

namespace SeriesVault.Migrations
{
    [DbContext(typeof(SeriesDbContext))]
    partial class SeriesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SeriesVault.Series", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Series");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Platform = "Netflix",
                            Producer = "J. J. Abrams, Jeffrey Lieber, Damon Lindelof",
                            Publisher = "American Broadcasting Company",
                            Title = "Lost"
                        },
                        new
                        {
                            id = 2,
                            Platform = "Netflix",
                            Producer = "Michael C. Hall",
                            Publisher = "Showtime, CBS",
                            Title = "Dexter"
                        },
                        new
                        {
                            id = 3,
                            Platform = "Netflix",
                            Producer = "Helen Pai",
                            Publisher = "ABC in the United States",
                            Title = "The Rookie"
                        },
                        new
                        {
                            id = 4,
                            Platform = "Amazon Prime",
                            Producer = "Eric Kripke",
                            Publisher = "Dynamite Entertainment",
                            Title = "The Boys"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
