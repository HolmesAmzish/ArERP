using ArERP.Areas.Production.Dtos;
using ArERP.Areas.Production.Models;
using ArERP.Areas.Production.Repository;

namespace ArERP.Areas.Production.Service.Impl;

public class MachineService : IMachineService
{
    private readonly IMachineRepository _machineRepository;

    public MachineService(IMachineRepository machineRepository)
    {
        _machineRepository = machineRepository;
    }

    public List<MachineStats> GetMachineStats()
    {
        var allMachines = _machineRepository.GetAllMachines();

        var groupedByWorkshop = allMachines
            .GroupBy(m => m.Workshop)
            .Select(g => new MachineStats
            {
                WorkshopId = g.Key.Id,
                WorkshopName = g.Key.Name,
                Machines = g.Select(m => new MachineItem
                {
                    MachineId = m.Id,
                    MachineCode = m.Code,
                    Status = m.Status
                }).ToList()
            })
            .ToList();

        return groupedByWorkshop;
    }
}