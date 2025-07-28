using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.Production.Models;
using ArERP.Dtos;

namespace ArERP.Service;

public interface IDashboardService
{
    List<EmployeeShiftStats> GetEmployeeShiftStats();
    List<WorkshopStats> GetWorkshopStats();
    List<WorkOrder> GetWorkOrders();
}