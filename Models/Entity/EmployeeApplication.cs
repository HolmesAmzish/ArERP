using System.ComponentModel.DataAnnotations;

namespace ArERP.Models.Entity;

public class EmployeeApplication
{
    // db field
    [Key]
    public int Id { get; set; }
    [Display(Name = "状态")]
    public ProcessStatus Status { get; set; } = ProcessStatus.Pending;
    public bool Deleted { get; set; } = false;

    // info field
    [Required]
    [Display(Name = "姓名")]
    public string Name { get; set; }
    [Display(Name = "性别")]
    public string Gender { get; set; } = "M";
    [Display(Name = "出生日期")]
    public DateTime DateOfBirth { get; set; }
    [Display(Name = "地址")]
    public string? Address { get; set; }
    [Required]
    [Display(Name = "身份证")]
    public string NationalId { get; set; }
    [Required]
    [Display(Name = "电话")]
    public string Phone { get; set; }
    [Display(Name = "邮箱")]
    public string? Email { get; set; }
    [Display(Name = "部门")]
    public int DepartmentId { get; set; }
    [Display(Name = "审批人")]
    public string? Approver { get; set; }
    [Display(Name = "审批意见")]
    public string? ApprovalNote { get; set; }
    [Display(Name = "申请日期")]
    public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
    [Display(Name = "审批日期")]
    public DateTime? ApprovalDate { get; set; }
}
