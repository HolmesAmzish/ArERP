namespace ArERP.Models.Entity.Inventory;

public class InventoryTransaction
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public Material Material { get; set; }
    
    public decimal Quantity { get; set; }
    public DateTime Date { get; set; }
    public InventoryTransactionType Type { get; set; }
}