using ArERP.Models;

namespace ArERP.Service;

public interface ISystemService
{
    List<SystemLog> GetAllSystemLogs();
}