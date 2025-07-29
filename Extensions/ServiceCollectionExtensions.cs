using Areas.Production.Service;
using Areas.Production.Service.Impl;
using ArERP.Areas.HumanResource.Repository;
using ArERP.Areas.HumanResource.Repository.Impl;
using ArERP.Areas.Inventory.Repository;
using ArERP.Areas.Inventory.Repository.Impl;
using ArERP.Areas.Inventory.Services;
using ArERP.Areas.Inventory.Services.Impl;
using ArERP.Areas.Production.Repository;
using ArERP.Areas.Production.Repository.Impl;
using ArERP.Service;
using ArERP.Service.Impl;

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
        
        // Production
        services.AddScoped<IBomRepository, BomRepository>();
        services.AddScoped<IShiftRepository, ShiftRepository>();
        services.AddScoped<IWorkshopRepository, WorkshopRepository>();
        services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
        return services;
    }

    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IInventoryBalanceService, InventoryBalanceService>();
        services.AddScoped<IBomService, BomService>();
        services.AddScoped<IDashboardService, DashboardService>();
        return services;
    }
}
