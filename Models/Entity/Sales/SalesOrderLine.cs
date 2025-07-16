using ArERP.Models.Entity.Production;

namespace ArERP.Models.Entity.Sales;

public class SalesOrderLine
{
    public int Id { get; set; }
    public int SalesOrderId { get; set; }
    public SalesOrder SalesOrder { get; set; }
    public Product Product { get; set; }
    public int quantity { get; set; }
    public decimal Price { get; set; }
}