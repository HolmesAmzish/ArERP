namespace ArERP.Models.Entity.Inventory;

public class Material
{
    public int Id { get; set; }
    public string MaterialCode { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public decimal Stock { get; set; }
}