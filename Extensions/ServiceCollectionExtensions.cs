using ArERP.Areas.HumanResource.Repository;
using ArERP.Areas.HumanResource.Repository.Impl;
using ArERP.Areas.Inventory.Repository;
using ArERP.Areas.Inventory.Repository.Impl;
using ArERP.Areas.Inventory.Services;
using ArERP.Areas.Inventory.Services.Impl;
using ArERP.Areas.Production.Repository;
using ArERP.Areas.Production.Repository.Impl;
using ArERP.Areas.Production.Service;
using ArERP.Areas.Production.Service.Impl;
using ArERP.Repository;
using ArERP.Repository.Impl;
using ArERP.Service;
using ArERP.Service.Impl;

namespace ArERP.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppRepositories(this IServiceCollection services)
    {
        // System
        services.AddScoped<ISystemLogRepository, SystemLogRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
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
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        
        // Production
        services.AddScoped<IBomRepository, BomRepository>();
        services.AddScoped<IShiftRepository, ShiftRepository>();
        services.AddScoped<IWorkshopRepository, WorkshopRepository>();
        services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
        services.AddScoped<IMachineRepository, MachineRepository>();
        
        return services;
    }

    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        // System
        services.AddScoped<ISystemLogService, SystemLogService>();
        services.AddScoped<ISystemService, SystemService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IAgentService, AgentService>();        
        
        // Inventory
        services.AddScoped<IInventoryBalanceService, InventoryBalanceService>();
        
        // Production
        services.AddScoped<IBomService, BomService>();
        services.AddScoped<IWorkOrderService, WorkOrderService>();
        services.AddScoped<IMachineService, MachineService>();
        services.AddScoped<IWorkshopService, WorkshopService>();
        

        
        return services;
    }
}
