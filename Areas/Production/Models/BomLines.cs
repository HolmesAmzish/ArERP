using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Areas.Inventory.Models;

namespace ArERP.Areas.Production.Models;

public class BomLines
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int BomHeaderId { get; set; }
    [ForeignKey("BomHeaderId")]
    public Bom BomHeader { get; set; }
    
    public int MaterialItemId { get; set; }
    [ForeignKey("MaterialItemId")]
    public Item Material { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }
}