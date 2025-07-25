using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.HumanResource.Repositories;
using ArERP.Areas.HumanResource.Repositories.Impl;
using ArERP.Models;
using ArERP.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 添加服务
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDerpartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeApplicationRepository, EmployeeApplicationRepository>();
builder.Services.AddScoped<IEmployeeSeparationRepository, EmployeeSeparationRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// 数据初始化
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// 中间件顺序
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 路由配置：替代 UseEndpoints，直接用 MapControllerRoute
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Panel}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Home}/{action=Index}/{id?}");

// 你的自定义 Minimal API 路由
app.MapGet("/hello/{name:alpha?}", (string? name) => $"Hello, {name ?? "World"}!");

app.Run();