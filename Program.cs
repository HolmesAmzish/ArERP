using ArERP.Data;
using ArERP.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI Setting
builder.Services.AddAppRepositories();
builder.Services.AddAppServices();
builder.Services.AddControllersWithViews();

// Log Setting
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddProvider(new SystemLogLoggerProvider(builder.Services.BuildServiceProvider()));
builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.None);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    HrSeedData.Initialize(services);
    InventorySeedData.Initialize(services);
    ProductionSeedData.Initialize(services);
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapGet("/hello/{name:alpha?}", (string? name) => $"Hello, {name ?? "World"}!");

app.Run();