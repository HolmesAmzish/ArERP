using ArERP.Areas.Production.Enum;
using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Repository;

public interface IWorkOrderRepository
{
    List<WorkOrder> GetAllWorkOrders();
    List<WorkOrder> GetWorkOrdersByStatus(OrderStatus status);
}