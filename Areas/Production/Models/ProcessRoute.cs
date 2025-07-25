namespace ArERP.Models.Entity.Production;

public class ProcessRoute
{
    public int Id { get; set; }
    public string RouteName { get; set; }
    public ICollection<ProcessStep> Steps { get; set; }
}