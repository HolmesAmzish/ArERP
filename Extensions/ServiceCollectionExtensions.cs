using ArERP.Areas.HumanResource.Repositories;
using ArERP.Areas.HumanResource.Repositories.Impl;
using ArERP.Areas.Inventory.Repository;
using ArERP.Areas.Inventory.Repository.Impl;

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
        return services;
    }
}
