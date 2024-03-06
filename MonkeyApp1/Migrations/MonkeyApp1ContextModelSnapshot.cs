﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonkeyApp1.Data;

#nullable disable

namespace MonkeyApp1.Migrations
{
    [DbContext(typeof(MonkeyApp1Context))]
    partial class MonkeyApp1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("MonkeyApp1.Models.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("MonkeyApp1.Models.Monkey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContinentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Population")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("Monkey");
                });

            modelBuilder.Entity("MonkeyApp1.Models.Monkey", b =>
                {
                    b.HasOne("MonkeyApp1.Models.Continent", null)
                        .WithMany("Monkeys")
                        .HasForeignKey("ContinentId");
                });

            modelBuilder.Entity("MonkeyApp1.Models.Continent", b =>
                {
                    b.Navigation("Monkeys");
                });
#pragma warning restore 612, 618
        }
    }
}
