using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using ArERP.Models.Enum;

namespace ArERP.Models.Entity.Inventory;

public class Item
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }
    public string Code { get; set; }
    public string name { get; set; }
    public ItemType type { get; set; }
    public string unit { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime CreateDate { get; set; } = DateTime.Now;
}