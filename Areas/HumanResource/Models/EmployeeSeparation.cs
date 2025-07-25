using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Models.Enum;

namespace ArERP.Areas.HumanResource.Models;

public class EmployeeSeparation
{
    // db field
    [Key]
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee EmployeeInfo { get; set; }
    [Display(Name = "状态")]
    public ProcessStatus Status { get; set; } = ProcessStatus.Pending;

    // info field
    [Display(Name = "离职原因")]
    public string? SeparationReason { get; set; }
    [Display(Name = "离职日期")]
    public DateTime SeparationDate { get; set; } = DateTime.Now;
    [Display(Name = "操作者")]
    public string? Approver { get; set; }
    [Display(Name = "审批意见")]
    public string? ApprovalNote { get; set; }
}
