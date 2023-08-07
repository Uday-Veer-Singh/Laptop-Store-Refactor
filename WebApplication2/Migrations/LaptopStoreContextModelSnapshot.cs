﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(LaptopStoreContext))]
    partial class LaptopStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.Brand", b =>
                {
                    b.Property<Guid>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("WebApplication2.Models.Laptop", b =>
                {
                    b.Property<Guid>("LaptopNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LaptopNumber");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("WebApplication2.Models.LaptopStore", b =>
                {
                    b.Property<Guid>("LaptopStoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LaptopNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StoreNumber")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LaptopStoreId");

                    b.HasIndex("LaptopNumber");

                    b.HasIndex("StoreNumber");

                    b.ToTable("LaptopStore");
                });

            modelBuilder.Entity("WebApplication2.Models.StoreLocation", b =>
                {
                    b.Property<Guid>("StoreNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreNumber");

                    b.ToTable("StoreLocations");
                });

            modelBuilder.Entity("WebApplication2.Models.LaptopStore", b =>
                {
                    b.HasOne("WebApplication2.Models.Laptop", "laptop")
                        .WithMany("laptopStores")
                        .HasForeignKey("LaptopNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.StoreLocation", "StoreLocation")
                        .WithMany("laptopStores")
                        .HasForeignKey("StoreNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoreLocation");

                    b.Navigation("laptop");
                });

            modelBuilder.Entity("WebApplication2.Models.Laptop", b =>
                {
                    b.Navigation("laptopStores");
                });

            modelBuilder.Entity("WebApplication2.Models.StoreLocation", b =>
                {
                    b.Navigation("laptopStores");
                });
#pragma warning restore 612, 618
        }
    }
}
