using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models.Entity.Sales;

public class SalesOrderLine
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int SalesOrderId { get; set; }
    [ForeignKey("SalesOrderId")]
    public SalesOrder SalesOrder { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal quantity { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
}