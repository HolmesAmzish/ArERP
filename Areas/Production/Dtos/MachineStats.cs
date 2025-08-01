using ArERP.Areas.Production.Enum;
using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Dtos;

public class MachineStats
{
    public int WorkshopId { get; set; }
    public string WorkshopName { get; set; }
    public List<MachineItem> Machines { get; set; }
}

public class MachineItem
{
    public int MachineId { get; set; }
    public string MachineCode { get; set; }
    public MachineStatus Status { get; set; }
}
