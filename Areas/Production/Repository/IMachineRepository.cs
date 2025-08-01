

using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Repository;

public interface IMachineRepository
{
    List<Machine> GetAllMachines();

    List<Machine> GetMachinesByWorkshopId(int workshopId);
}