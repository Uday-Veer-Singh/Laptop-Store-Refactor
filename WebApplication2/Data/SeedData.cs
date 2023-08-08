using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            LaptopStoreContext context = new LaptopStoreContext(serviceProvider.GetRequiredService<DbContextOptions<LaptopStoreContext>>());
            context.Database.EnsureDeleted();
            context.Database.Migrate();

{
    public class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            LaptopStoreContext db = new LaptopStoreContext(serviceProvider.GetRequiredService<DbContextOptions<LaptopStoreContext>>());
           
            db.Database.EnsureDeleted();
            db.Database.Migrate();
            Brand brand1 = new Brand { Name = "Omen"};  
            Brand brand2 = new Brand { Name = "Vivo"};  
            Brand brand3 = new Brand { Name = "Xiomi"};

            if (!db.Brands.Any()) {
                db.Brands.Add(brand1);
                db.Brands.Add(brand2);
                db.Brands.Add(brand3);
                db.SaveChanges();
            }

            StoreLocation store1 = new StoreLocation
            {

                StreetName = "MayFair Place",
                StreetNumber = 111,
                Province = Province.Ontario
            };

            StoreLocation store2 = new StoreLocation
            {

                StreetName = "MayFair Avenue",
                StreetNumber = 112,
                Province = Province.Manitoba
            };

            StoreLocation store3 = new StoreLocation
            {

                StreetName = "MayFair Boulevard",
                StreetNumber = 113,
                Province = Province.BritishColumbia
            };

            StoreLocation store4 = new StoreLocation
            {

                StreetName = "MayFair",
                StreetNumber = 114,
                Province = Province.Alberta
            };

            if (!db.StoreLocations.Any())
            {
                db.StoreLocations.Add(store1);
                db.StoreLocations.Add(store2);
                db.StoreLocations.Add(store3);
                db.StoreLocations.Add(store4);
                db.SaveChanges();
            }

            Laptop laptop1 = new Laptop
            {
                Model = "misi",
                Price = 564,
                Condition = LaptopCondition.New,
                Brand = brand1
            };

            Laptop laptop2 = new Laptop
            {
                Model = "ollup",
                Price = 652,
                Condition = LaptopCondition.New,
                Brand = brand1
            };

            Laptop laptop3 = new Laptop
            {
                Model = "guddr",
                Price = 863,
                Condition = LaptopCondition.Refurbished,
                Brand = brand2
            };

            Laptop laptop4 = new Laptop
            {
                Model = "waile",
                Price = 758,
                Condition = LaptopCondition.New,
                Brand = brand3
            };

            Laptop laptop5 = new Laptop
            {
                Model = "booogi",
                Price = 200,
                Condition = LaptopCondition.Rental,
                Brand = brand3
            };

            if (!db.Laptops.Any())
            {
                db.Laptops.Add(laptop1);
                db.Laptops.Add(laptop2);
                db.Laptops.Add(laptop3);
                db.Laptops.Add(laptop4);
                db.Laptops.Add(laptop5);
                db.SaveChanges();
            }

            LaptopStore laptopStore1 = new LaptopStore
            {
                LaptopStoreId = Guid.NewGuid(),
                StoreNumber = store1.StoreNumber,
                LaptopNumber = laptop1.LaptopNumber,
                Quantity = 5

            };

            LaptopStore laptopStore2 = new LaptopStore
            {
                LaptopStoreId = Guid.NewGuid(),
                StoreNumber = store2.StoreNumber,
                LaptopNumber = laptop2.LaptopNumber,
                Quantity = 25

            };

            LaptopStore laptopStore3 = new LaptopStore
            {
                LaptopStoreId = Guid.NewGuid(),
                StoreNumber = store3.StoreNumber,
                LaptopNumber = laptop3.LaptopNumber,
                Quantity = 12

            };

            LaptopStore laptopStore4 = new LaptopStore
            {
                LaptopStoreId = Guid.NewGuid(),
                StoreNumber = store4.StoreNumber,
                LaptopNumber = laptop4.LaptopNumber,
                Quantity = 42

            };

            LaptopStore laptopStore5 = new LaptopStore
            {
                LaptopStoreId = Guid.NewGuid(),
                StoreNumber = store2.StoreNumber,
                LaptopNumber = laptop5.LaptopNumber,
                Quantity = 4

            };

            LaptopStore laptopStore6 = new LaptopStore
            {
                LaptopStoreId = Guid.NewGuid(),
                StoreNumber = store4.StoreNumber,
                LaptopNumber = laptop5.LaptopNumber,
                Quantity = 5

            };
            if (!db.LaptopStore.Any())
            {
                db.LaptopStore.Add(laptopStore1);
                db.LaptopStore.Add(laptopStore2);
                db.LaptopStore.Add(laptopStore3);
                db.LaptopStore.Add(laptopStore4);
                db.LaptopStore.Add(laptopStore5);
                db.LaptopStore.Add(laptopStore6);
                db.SaveChanges();
            }

        }
    }
}
