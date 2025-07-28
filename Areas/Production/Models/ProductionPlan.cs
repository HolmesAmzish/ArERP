using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Areas.Inventory.Models;

namespace ArERP.Areas.Production.Models;

public class ProductionPlan
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Item Product { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }

    public DateTime PlannedStart { get; set; }
    public DateTime PlannedEnd { get; set; }

    public string? Remark { get; set; }
}
