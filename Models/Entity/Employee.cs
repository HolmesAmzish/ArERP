using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models.Entity;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "工号")]
    public int Id { get; set; }

    [Display(Name = "姓名")]
    [Required(ErrorMessage = "员工姓名不能为空")]
    [StringLength(100, ErrorMessage = "员工姓名长度不能超过100个字符")]
    public string EmployeeName { get; set; }

    [Display(Name = "性别")]
    [StringLength(10)]
    public string Gender { get; set; }

    [Display(Name = "出生日期")]
    public DateTime? BirthDate { get; set; }

    [EmailAddress(ErrorMessage = "邮箱格式不正确")]
    [StringLength(255)]
    [Display(Name = "邮箱")]
    public string Email { get; set; }

    [Display(Name = "手机")]
    [StringLength(50)]
    public string Phone { get; set; }

    [Display(Name = "入职时间")]
    [DataType(DataType.Date)]
    public DateTime HireDate { get; set; } = DateTime.Now;

    [Display(Name = "部门")]
    [StringLength(100)]
    public string Department { get; set; }

    [Display(Name = "职位")]
    [StringLength(100)]
    public string Position { get; set; }

    [Display(Name = "薪资")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }

    public bool IsActive { get; set; } = true;

    public Employee() { }
}

