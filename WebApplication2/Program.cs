using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication2.Data;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<LaptopStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaptopConnectionString"));
});



builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider serviceProvider = scope.ServiceProvider;
    await SeedData.Initialize(serviceProvider);
}


app.MapGet("/laptops/search", (LaptopStoreContext
    db, decimal priceAbove, decimal priceBelow, int storeStock,
    string province, LaptopCondition condition, Guid brandId, string searchPhrase) =>
{
    try
    {
        if (priceAbove > 0)
        {
            return Results.Ok(db.Laptops.Where(l => l.Price > priceAbove));
        }
        else if (priceBelow > 0)
        {
            return Results.Ok(db.Laptops.Where(l => l.Price < priceBelow));
        }
        else if (storeStock > 0)
        {
            return Results.Ok(db.LaptopStore.Where(s => s.Quantity > 0));
        }
        else if (condition == LaptopCondition.New || condition == LaptopCondition.Refurbished ||
            condition == LaptopCondition.Rental)
        {
            return Results.Ok(db.Laptops.Where(l => l.Condition == condition));
        }
        else if (randId > 0)
        {
            return Results.Ok(db.Laptops.Where(l => l.BrandId == brandId));
        }
        else if (searchPhrase.Length > 0)
        {
            return Results.Ok(db.Laptops.Where(l => l.Model.Contains(searchPhrase)));
        }
        else
        {
            return Results.Ok(db.Laptops.ToList());
        }
    }
    catch (ArgumentException)
    {
        throw new ArgumentException("Invalid values");
    }
});

// An endpoint which dynamically groups and returns all Stores according to the Province in which they
// are in. This endpoint should not display any data from any model other than the Stores queried, and
// should only display provinces that have stores in them.
app.MapGet("/stores/{storeNumber}/inventory", async (LaptopStoreContext context, Guid storeNumber) =>
{
    try
    {
        List<LaptopStore> laptops = await context.LaptopStore
                .Where(l => l.StoreNumber == storeNumber && l.Quantity > 0)
            .Include(l => l.laptop)
            .ThenInclude(l => l.Brand)
            .ToListAsync();

        if (laptops.Count == 0)
        {
            return Results.NotFound("No laptops with quantity greater than 0 found in the store.");
        }

        return Results.Ok(laptops);
    }
    catch (Exception ex)
    {
        return Results.Problem($"An error occurred: {ex.Message}");
    }
});





app.Run();
