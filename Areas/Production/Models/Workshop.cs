using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.Production.Models;

public class Workshop
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required] [Display(Name = "车间名称")]
    public string Name { get; set; }
    
    [Required] [Display(Name = "车间编码")]
    public string Code { get; set; }
    
    [Comment("Overall Equipment Effectiveness")]
    [Display(Name = "设备综合效率")] [Column(TypeName = "decimal(5, 2)")]
    public decimal Oee { get; set; }
    
    [Display(Name = "工作负荷")] [Column(TypeName = "decimal(5, 2)")]
    public decimal Workload { get; set; }
}