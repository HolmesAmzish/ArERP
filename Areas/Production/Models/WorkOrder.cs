using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Areas.Inventory.Models;
using ArERP.Areas.Production.Enum;

namespace ArERP.Areas.Production.Models;

public class WorkOrder
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string OrderNumber { get; set; }
    
    public int ProductItemId { get; set; }
    [ForeignKey("ProductItemId")]
    public Item Product { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }
    public DateTime ScheduledDate { get; set; }
    public OrderStatus Status { get; set; }
}