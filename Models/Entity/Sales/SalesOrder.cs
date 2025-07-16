namespace ArERP.Models.Entity.Sales;

public class SalesOrder
{
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<SalesOrderLine> Lines { get; set; }
}