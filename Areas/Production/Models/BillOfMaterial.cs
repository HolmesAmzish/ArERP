using ArERP.Areas.Inventory.Models;

namespace ArERP.Models.Entity.Production;

public class BillOfMaterial
{
    public int Id { get; set; }
    public int WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; }

    public int MaterialId { get; set; }
    public Item Material { get; set; }

    public decimal RequiredQuantity { get; set; }
    public decimal IssuedQuantity { get; set; }
    public string UnitOfMeasure { get; set; }

    public string? BatchNumber { get; set; }
}