using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Repository;

public interface IWorkOrderRepository
{
    List<WorkOrder> GetAllWorkOrders();
}