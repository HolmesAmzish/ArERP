using ArERP.Models;

namespace ArERP.Repository;

public interface ISystemLogRepository
{
    List<SystemLog> GetAllSystemLogs();
    void AddLog(SystemLog log);
}