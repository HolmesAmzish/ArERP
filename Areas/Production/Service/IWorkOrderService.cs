using ArERP.Areas.Production.Dtos;
using ArERP.Areas.Production.Models;
using ArERP.Dtos;

namespace ArERP.Areas.Production.Service;

public interface IWorkOrderService
{
    List<WorkOrder> GetAllWorkOrders();
    PagedResult<WorkOrder> GetPagedWorkOrders(int pageIndex, int pageSize);
    public List<WorkOrderStats> GetWorkOrderStats();
}