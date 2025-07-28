using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.HumanResource.Models;

public class Department
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] [Display(Name = "部门代号")]
    public int Id { get; set; }
    
    [Required] [Display(Name = "部门名称")]
    public string DepartmentName { get; set; } 
    
    [Display(Name = "建立时间")]
    public DateTime CreationDate { get; set; }
    
    [Display(Name = "是否删除")]
    public bool Deleted { get; set; }
}