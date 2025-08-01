using ArERP.Areas.Production.Dtos;
using ArERP.Areas.Production.Repository;

namespace ArERP.Areas.Production.Service;

public interface IMachineService
{
    List<MachineStats> GetMachineStats();
}