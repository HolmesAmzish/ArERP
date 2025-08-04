using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Areas.Inventory.Models;
using ArERP.Areas.Production.Enum;

namespace ArERP.Areas.Production.Models;

public class WorkOrder
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string OrderNumber { get; set; } = null!;
    
    [Required]
    public int ProductItemId { get; set; }

    [Required] [ForeignKey("ProductItemId")]
    public Item Product { get; set; } = null!;
    
    [Required] [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }
    
    [Column(TypeName = "decimal(5,2)")]
    public decimal ProductionProcess { get; set; }
    public DateTime ScheduledDate { get; set; }
    public OrderStatus Status { get; set; }
}