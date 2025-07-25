using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models.Entity.Inventory;

public class Warehouse
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string? Location { get; set; }
    
    public decimal MaxCapacity { get; set; }

    public decimal CurrentCapacity { get; set; } = 0;
}