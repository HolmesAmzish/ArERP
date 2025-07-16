namespace ArERP.Models.Entity.Production;

public class WorkOrder
{
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public DateTime ScheduledDate { get; set; }
    public OrderStatus Status { get; set; }
}