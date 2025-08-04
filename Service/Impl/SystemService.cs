using ArERP.Models;
using ArERP.Repository;

namespace ArERP.Service.Impl;

public class SystemService : ISystemService
{
    private readonly ISystemLogService _systemLogService;

    public SystemService(ISystemLogService systemLogService)
    {
        this._systemLogService = systemLogService;
    }

    public List<SystemLog> GetAllSystemLogs() => _systemLogService.GetAllSystemLogs();
}