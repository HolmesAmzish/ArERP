using ArERP.Dtos;
using ArERP.Models;

namespace ArERP.Service;

public interface ISystemLogService
{
    List<SystemLog> GetAllSystemLogs();
    PagedResult<SystemLog> GetPagedSystemLogs(int pageIndex, int pageSize);
    void Info(string content);

}
