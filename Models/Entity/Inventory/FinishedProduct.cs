namespace ArERP.Models.Entity.Inventory;

public class FinishedProduct
{
    public int Id { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public decimal Stock { get; set; }
}