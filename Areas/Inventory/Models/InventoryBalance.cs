using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Inventory.Models;

public class InventoryBalance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Display(Name="物品ID")]
    public int ItemId { get; set; }
    [ForeignKey("ItemId")]
    public Item Item { get; set; }
    
    [Display(Name="仓库ID")]
    public int WarehouseId { get; set; }
    
    [ForeignKey("WarehouseId")]
    public Warehouse Warehouse { get; set; }
    
    [Display(Name="存储数量")]
    public decimal Quantity { get; set; }
    
    [Display(Name="更新日期")]
    public DateTime LastUpdated { get; set; }
}