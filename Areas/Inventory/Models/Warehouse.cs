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
    [Display(Name="最大存储")]
    public decimal MaxCapacity { get; set; }
    [Display(Name="当前存储")]
    public decimal CurrentCapacity { get; set; } = 0;
}