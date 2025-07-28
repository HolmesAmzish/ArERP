using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Procurement.Models;

public class Supplier
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string SupplierCode { get; set; }
    
    public string Name { get; set; }
    
    public string ContactInfo { get; set; }
}