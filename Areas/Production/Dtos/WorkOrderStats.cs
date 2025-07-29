using ArERP.Areas.Production.Enum;

namespace ArERP.Areas.Production.Dtos;

public class WorkOrderStats
{
    public OrderStatus OrderStatus { get; set; }
    public int OrderCount { get; set; }
}