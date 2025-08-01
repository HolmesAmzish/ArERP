using ArERP.Models;
using ArERP.Repository;

namespace ArERP.Service.Impl;

public class SystemLogService : ISystemLogService
{
    private readonly ISystemLogRepository _systemLogRepository;

    public SystemLogService(ISystemLogRepository systemLogRepository)
    {
        this._systemLogRepository = systemLogRepository;
    }

    public void Info(string content)
    {
        var log = new SystemLog { Content = content, Level = LogLevel.Information, RecordTime = DateTime.Now };
        _systemLogRepository.AddLog(log);
    }
}