namespace ArERP.Models.Entity.Production;

public class Machine
{
    public int Id { get; set; }
    public string MachineCode { get; set; }
    public string Name { get; set; }
    public MachineStatus Status { get; set; }
}