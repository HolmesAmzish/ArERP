using ArERP.Areas.Production.Dtos;
using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Service;

public interface IWorkOrderService
{
    List<WorkOrder> GetAllWorkOrders();
    public List<WorkOrderStats> GetWorkOrderStats();
}