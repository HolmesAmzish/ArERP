using ArERP.Dtos;
using ArERP.Models;

namespace ArERP.Repository;

public interface ISystemLogRepository
{
    List<SystemLog> GetAllSystemLogs();
    PagedResult<SystemLog> GetPagedSystemLogs(int pageIndex, int pageSize);
    void AddLog(SystemLog log);
}
