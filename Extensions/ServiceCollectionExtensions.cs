using ArERP.Areas.HumanResource.Repositories;
using ArERP.Areas.HumanResource.Repositories.Impl;
using ArERP.Areas.Inventory.Repository;
using ArERP.Areas.Inventory.Repository.Impl;
using ArERP.Areas.Inventory.Services;
using ArERP.Areas.Inventory.Services.Impl;

namespace ArERP.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppRepositories(this IServiceCollection services)
    {
        // HumanResource
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDerpartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeApplicationRepository, EmployeeApplicationRepository>();
        services.AddScoped<IEmployeeSeparationRepository, EmployeeSeparationRepository>();
        services.AddScoped<IEvaluationRepository, EvaluationRepository>();
        
        // Inventory
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        services.AddScoped<IInventoryBalanceRepository, InventoryBalanceRepository>();
        return services;
    }

    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IInventoryBalanceService, InventoryBalanceService>();
        return services;
    }
}
