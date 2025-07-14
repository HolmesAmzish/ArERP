using ArERP.Configuration;
using ArERP.Models;
using ArERP.Repository;
using ArERP.Repository.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDerpartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeApplicationRepository, EmployeeApplicationRepository>();
builder.Services.AddScoped<IEmployeeSeparationRepository, EmployeeSeparationRepository>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();
builder.Services.AddControllersWithViews();

builder.Services.Configure<JsonWebTokenConfig>(
    builder.Configuration.GetSection("JwtConfig"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
