using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.HumanResource.Repository;
using ArERP.Areas.Production.Models;
using ArERP.Areas.Production.Repository;
using ArERP.Dtos;

namespace ArERP.Service.Impl;

public class DashboardService : IDashboardService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IShiftRepository _shiftRepository;
    private readonly IWorkshopRepository _workshopRepository;
    private readonly IWorkOrderRepository _workOrderRepository;

    public DashboardService(
        IEmployeeRepository employeeRepository,
        IShiftRepository shiftRepository,
        IWorkshopRepository workshopRepository,
        IWorkOrderRepository workOrderRepository)
    {
        this._employeeRepository = employeeRepository;
        this._shiftRepository = shiftRepository;
        this._workshopRepository = workshopRepository;
        this._workOrderRepository = workOrderRepository;
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
            });
        }

        return results;
    }

    public List<Workshop> GetWorkshopStats()
    {
        List<Workshop> allWorkshops = _workshopRepository.GetAllWorkshops();
        Console.WriteLine(allWorkshops);
        return allWorkshops;
    }

    public List<WorkOrder> GetWorkOrders() =>
        _workOrderRepository
            .GetAllWorkOrders();
}