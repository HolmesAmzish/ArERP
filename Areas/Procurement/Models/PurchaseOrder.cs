namespace ArERP.Models.Entity.Procurement;

public class PurchaseOrder
{
    public int Idd { get; set; }
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    public ICollection<PurchaseOrderLine> Lines { get; set; }
}