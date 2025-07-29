using ArERP.Areas.Production.Models;
using ArERP.Data;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.Production.Repository.Impl;

public class WorkOrderRepository : IWorkOrderRepository
{
    private readonly AppDbContext _context;

    public WorkOrderRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<WorkOrder> GetAllWorkOrders() => 
        _context.WorkOrders
            .Include(wo => wo.Product)
            .ToList();
}