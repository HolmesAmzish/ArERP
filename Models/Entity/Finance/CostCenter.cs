namespace ArERP.Models.Entity.Finance;

public class CostCenter
{
    public int Id { get; set; }
    public string Name { get; set; }    // e.g., "Production Department"
    public string Code { get; set; }    // e.g., "PROD01"
}
