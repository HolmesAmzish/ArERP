using ArERP.Areas.Production.Enum;
using ArERP.Areas.Production.Models;
using ArERP.Dtos;

namespace ArERP.Areas.Production.Repository;

public interface IWorkOrderRepository
{
    List<WorkOrder> GetAllWorkOrders();
    PagedResult<WorkOrder> GetPagedWorkOrders(int pageIndex, int pageSize);
    List<WorkOrder> GetWorkOrdersByStatus(OrderStatus status);
}