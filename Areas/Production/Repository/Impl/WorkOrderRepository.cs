using ArERP.Areas.Production.Enum;
using ArERP.Areas.Production.Models;
using ArERP.Data;
using ArERP.Dtos;
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

    public PagedResult<WorkOrder> GetPagedWorkOrders(int pageIndex, int pageSize)
    {
        var query = _context.WorkOrders;

        int totalCount = query.Count();

        var items = query
            .OrderBy(m => m.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .Include(wo => wo.Product)
            .ToList();

        return new PagedResult<WorkOrder>
        {
            TotalCount = totalCount,
            Items = items
        };
    }
    
    public List<WorkOrder> GetWorkOrdersByStatus(OrderStatus status) =>
        _context.WorkOrders
            .Include(wo => wo.Product)
            .Where(wo => wo.Status == status)
            .ToList();
}