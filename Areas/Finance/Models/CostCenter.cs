using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Finance.Models;

public class CostCenter
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }    // e.g., "Production Department"
    
    public string Code { get; set; }    // e.g., "PROD01"
}
