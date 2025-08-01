using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.Production.Dtos;
using ArERP.Areas.Production.Models;
using ArERP.Dtos;

namespace ArERP.Service;

public interface IDashboardService
{
    List<EmployeeShiftStats> GetEmployeeShiftStats();
    List<Workshop> GetWorkshopStats();
    PagedResult<WorkOrder> GetWorkOrders(int pageIndex = 1, int pageSize = 15);
    List<WorkOrderStats> GetWorkOrderStats();
    List<ProductionTransactionStats> GetAllProductionTransactions();
    List<MachineStats> GetMachineStats();
}