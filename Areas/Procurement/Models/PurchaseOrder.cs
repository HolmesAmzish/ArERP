using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Procurement.Models;

public class PurchaseOrder
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    
    public int SupplierId { get; set; }
    [ForeignKey("SupplierId")]
    public Supplier Supplier { get; set; }
    
    public ICollection<PurchaseOrderLine> Lines { get; set; }
}