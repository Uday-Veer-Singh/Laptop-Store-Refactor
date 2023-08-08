using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication2.Data;

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

app.Run();
