using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Areas.Inventory.Enum;

namespace ArERP.Areas.Inventory.Models;

public class Item
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "物品编号")]
    public int Id { get;set; }
    
    [Display(Name="代号")]
    public string Code { get; set; }
    
    [Display(Name="物品名称")]
    public string Name { get; set; }
    
    [Display(Name="物品类型")]
    public ItemType Type { get; set; }
    
    [Display(Name="单位")]
    public string Unit { get; set; }
    
    [Display(Name="创建日期")] [DataType(DataType.Date)]
    public DateTime CreateDate { get; set; } = DateTime.Now;
}