namespace ArERP.Models.Entity.Production;

public class ProcessStep
{
    public int Id { get; set; }
    public int RouteId { get; set; }
    public ProcessRoute Route { get; set; }
    public string StepName { get; set; }
    public int Sequence { get; set; }
}