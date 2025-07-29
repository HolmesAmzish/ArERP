using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.HumanResource.Repository;
using ArERP.Areas.Inventory.Models;
using ArERP.Areas.Inventory.Repository;
using ArERP.Areas.Production.Dtos;
using ArERP.Areas.Production.Models;
using ArERP.Areas.Production.Repository;
using ArERP.Areas.Production.Service;
using ArERP.Dtos;

namespace ArERP.Service.Impl;

public class DashboardService : IDashboardService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IShiftRepository _shiftRepository;
    private readonly IWorkshopRepository _workshopRepository;
    private readonly IWorkOrderService _workOrderService;
    private readonly ITransactionRepository _transactionRepository;

    public DashboardService(
        IEmployeeRepository employeeRepository,
        IShiftRepository shiftRepository,
        IWorkshopRepository workshopRepository,
        IWorkOrderService workOrderService,
        ITransactionRepository transactionRepository
    )
    {
        this._employeeRepository = employeeRepository;
        this._shiftRepository = shiftRepository;
        this._workshopRepository = workshopRepository;
        this._workOrderService = workOrderService;
        this._transactionRepository = transactionRepository;
    }

    public List<EmployeeShiftStats> GetEmployeeShiftStats()
    {
        List<Employee> allEmployee = _employeeRepository.GetAllEmployees();
        List<Shift> allShifts = _shiftRepository.GetAllShifts();

        var results = new List<EmployeeShiftStats>();

        foreach (var shift in allShifts)
        {
            int employeeNumber = allEmployee.Count(e => e.ShiftId == shift.Id);
            results.Add(new EmployeeShiftStats
                {
                    Shift = shift,
                    EmployeeNumber = employeeNumber
                }
            );
        }

        return results;
    }

    public List<Workshop> GetWorkshopStats()
    {
        List<Workshop> allWorkshops = _workshopRepository.GetAllWorkshops();
        // Console.WriteLine(allWorkshops);
        return allWorkshops;
    }

    public List<WorkOrder> GetAllWorkOrders() => _workOrderService.GetAllWorkOrders();

    public List<WorkOrderStats> GetWorkOrderStats() => _workOrderService.GetWorkOrderStats();
    
    public List<ProductionTransactionStats> GetAllProductionTransactions()
    {
        var allTransactions = _transactionRepository.GetAllTransactions();

        // Console.WriteLine(allTransactions.Count);
        List<string> allProductions = allTransactions
            .Where(t => t.Type == TransactionType.ProductionOutputInbound)
            .SelectMany(t => t.Lines)
            .Select(line => line.Item.Name)
            .Distinct()
            .ToList();
        // Console.WriteLine(allProductions.Count);
        
        var result = new List<ProductionTransactionStats>();

        foreach (var productionName in allProductions)
        {
            var linesForProduction = allTransactions
                .SelectMany(t => t.Lines
                    .Where(line => line.Item.Name == productionName)
                    .Select(line => new ProductionData
                    {
                        RecordTime = t.Date,
                        Quantity = line.Quantity
                    }))
                .ToList();

            result.Add(new ProductionTransactionStats
            {
                Production = productionName,
                Data = linesForProduction
            });
        }
        var json = System.Text.Json.JsonSerializer.Serialize(result);
        // Console.WriteLine($"Result:{json.Substring(0, Math.Min(500, json.Length))}");
        return result;
    }
}