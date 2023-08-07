using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class LaptopStoreContext : DbContext
    {
        public LaptopStoreContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>().HasKey(l => l.LaptopNumber);
            modelBuilder.Entity<StoreLocation>().HasKey(sl => sl.StoreNumber);
            modelBuilder.Entity<Brand>().HasKey(b => b.BrandId);

            modelBuilder.Entity<LaptopStore>().HasKey(sl => sl.LaptopStoreId);

            modelBuilder.Entity<LaptopStore>()
                .HasOne(sl => sl.StoreLocation)
                .WithMany(s => s.laptopStores)
                .HasForeignKey(sl => sl.StoreNumber);

            modelBuilder.Entity<LaptopStore>()
                .HasOne(sl => sl.laptop)
                .WithMany(l => l.laptopStores)
                .HasForeignKey(ls => ls.LaptopNumber);
        }


        public DbSet<Laptop> Laptops { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<StoreLocation> StoreLocations { get; set; } = null!;
        public DbSet<LaptopStore> LaptopStore { get; set; } = null!;
    }

}