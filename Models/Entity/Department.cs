using System.ComponentModel.DataAnnotations;

namespace ArERP.Models.Entity;

public class Department
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Display(Name = "部门名称")]
    public string DepartmentName { get; set; } 
    [Display(Name = "建立时间")]
    public DateTime CreationDate { get; set; }
    public bool Deleted { get; set; }
}