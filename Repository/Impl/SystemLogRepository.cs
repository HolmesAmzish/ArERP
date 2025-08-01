using ArERP.Data;
using ArERP.Models;

namespace ArERP.Repository.Impl;

public class SystemLogRepository : ISystemLogRepository
{
    private readonly AppDbContext _context;

    public SystemLogRepository(AppDbContext context)
    {
        this._context = context;
    }
    
    public void AddLog(SystemLog log)
    {
        _context.SystemLogs.Add(log);
        _context.SaveChanges();
    }
}