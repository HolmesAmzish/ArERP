using ArERP.Areas.Production.Dtos;
using ArERP.Areas.Production.Enum;
using ArERP.Areas.Production.Models;
using ArERP.Areas.Production.Repository;

namespace ArERP.Areas.Production.Service.Impl;

public class WorkOrderService : IWorkOrderService
{
    private readonly IWorkOrderRepository _workOrderRepository;

    public WorkOrderService(IWorkOrderRepository workOrderRepository)
    {
        this._workOrderRepository = workOrderRepository;
    }

    public List<WorkOrder> GetAllWorkOrders() => _workOrderRepository.GetAllWorkOrders();

    public List<WorkOrderStats> GetWorkOrderStats()
    {
        var result = new List<WorkOrderStats>();

        foreach (OrderStatus status in System.Enum.GetValues(typeof(OrderStatus)))
        {
            var count = _workOrderRepository.GetWorkOrdersByStatus(status).Count();
            result.Add(new WorkOrderStats
            {
                OrderStatus = status,
                OrderCount = count
            });
            // Console.WriteLine(result.Count);
        }

        return result;
    }

}