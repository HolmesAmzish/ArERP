using ArERP.Models;

namespace ArERP.Repository;

public interface ISystemLogRepository
{
    void AddLog(SystemLog log);
}