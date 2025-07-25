using System.ComponentModel.DataAnnotations;

namespace ArERP.Models.Enum;

public enum ItemType
{
    [Display(Name="材料")]
    Material,
    [Display(Name="半成品")]
    SemiProduct,
    [Display(Name="成品")]
    FinishedProduct,
    [Display(Name="消耗品")]
    Consumable
}