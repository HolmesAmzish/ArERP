using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Inventory.Models;

public class Item
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }
    [Display(Name="代号")]
    public string Code { get; set; }
    public string name { get; set; }
    [Display(Name="物品类型")]
    public ItemType type { get; set; }
    [Display(Name="单位")]
    public string unit { get; set; }
    
    [Display(Name="创建日期")]
    [DataType(DataType.Date)]
    public DateTime CreateDate { get; set; } = DateTime.Now;
}