using ArERP.Areas.Production.Models;
using ArERP.Data;

namespace ArERP.Areas.Production.Repository.Impl;

public class WorkOrderRepositoryRepository : IWorkOrderRepository
{
    private readonly AppDbContext _context;

    public WorkOrderRepositoryRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<WorkOrder> GetAllWorkOrders() => 
        _context.WorkOrders
            .ToList();
}