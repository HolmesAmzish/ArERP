using ArERP.Models.Entity.Inventory;

namespace ArERP.Models.Entity.Procurement;

public class PurchaseOrderLine
{
    public int Id { get; set; }
    public int PurchaseOrderId { get; set; }
    public PurchaseOrder PurchaseOrder { get; set; }

    public int MaterialId { get; set; }
    public Item Material { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}