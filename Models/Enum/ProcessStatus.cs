using System.ComponentModel.DataAnnotations;

namespace ArERP.Models;

public enum ProcessStatus
{
    [Display(Name = "待处理")]
    Pending = 0,
    [Display(Name = "已通过")]
    Approved = 1,
    [Display(Name = "已拒绝")]
    Rejected = 2
}