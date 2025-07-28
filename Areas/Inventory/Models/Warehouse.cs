using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Inventory.Models;

public class Warehouse
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Display(Name="仓库名称")]
    public string Name { get; set; }
    [Display(Name="仓库位置")]
    public string? Location { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public bool Deleted { get; set; } = false;
}