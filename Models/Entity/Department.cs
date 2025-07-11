using System.ComponentModel.DataAnnotations;

namespace ArERP.Models.Entity;

public class Department
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string DepartmentName { get; set; } 
    public DateTime CreationDate { get; set; }
    public bool Deleted { get; set; }
}