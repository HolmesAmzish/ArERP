namespace ArERP.Models.Entity.Production;

public class MaintenanceRequest
{
    public int Id { get; set; }
    public int MachineId { get; set; }
    public Machine Machine { get; set; }

    public DateTime RequestedAt { get; set; }
    public string IssueDescription { get; set; }

    public bool IsResolved { get; set; }
    public DateTime? ResolvedAt { get; set; }
}