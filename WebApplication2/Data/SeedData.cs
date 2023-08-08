using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
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

            if (!context.Brands.Any())
            {
                Brand brand1 = new Brand { Name = "Acer" };
                Brand brand2 = new Brand { Name = "Apple" };
                Brand brand3 = new Brand { Name = "Lenovo" };

                context.Brands.AddRange(brand1, brand2, brand3);
                context.SaveChanges();
            }
           

            if (!context.StoreLocations.Any())
            {
                StoreLocation location1 = new StoreLocation { Name = "Store 1", Address = "Address 1" };
                StoreLocation location2 = new StoreLocation { Name = "Store 2", Address = "Address 2" };
                StoreLocation location3 = new StoreLocation { Name = "Store 3", Address = "Address 3" };

                context.StoreLocations.AddRange(location1, location2, location3);
                context.SaveChanges();
            }

          

        }
    }
}
