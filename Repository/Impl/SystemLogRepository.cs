using ArERP.Data;
using ArERP.Dtos;
using ArERP.Models;

namespace ArERP.Repository.Impl;

public class SystemLogRepository : ISystemLogRepository
{
    private readonly AppDbContext _context;

    public SystemLogRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<SystemLog> GetAllSystemLogs() =>
        _context.SystemLogs
            .OrderByDescending(log => log.Id)
            .ToList();

    public PagedResult<SystemLog> GetPagedSystemLogs(int pageIndex, int pageSize)
    {
        var query = _context.SystemLogs;

        int totalCount = query.Count();

        var items = query
            .OrderByDescending(log => log.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedResult<SystemLog>
        {
            TotalCount = totalCount,
            Items = items
        };
    }

    public void AddLog(SystemLog log)
    {
        _context.SystemLogs.Add(log);
        _context.SaveChanges();
    }
}
