namespace ArERP.Models.Entity.Production;

public class Product
{
    public int Id { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Unit { get; set; }
    public decimal StandardCost { get; set; }
    public decimal SalePrice { get; set; }
    public bool IsActivate { get; set; }
    public ICollection<WorkOrder> WorkOrders { get; set; }
}