using System.ComponentModel.DataAnnotations;

namespace ArERP.Areas.Production.Enum;

public enum OrderStatus
{
    [Display(Name = "已计划")]
    Planned,
    [Display(Name = "进行中")]
    InProgress,
    [Display(Name = "已完成")]
    Completed
}