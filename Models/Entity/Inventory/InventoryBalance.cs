using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models.Entity.Inventory;

public class InventoryBalance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int ItemId { get; set; }
    [ForeignKey("ItemId")]
    public Item Item { get; set; }
    
    public int WarehouseId { get; set; }
    
    [ForeignKey("WarehouseId")]
    public Warehouse Warehouse { get; set; }
    
    public string LocationCode { get; set; }
    
    public decimal Quantity { get; set; }
    
    public DateTime LastUpdated { get; set; }
}