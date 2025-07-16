namespace ArERP.Models.Entity.Production;

public class ProcessOutput
{
    public int Idd { get; set; }
    public int WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; }
    public int Quantity { get; set; }
    public DateTime OutputTime { get; set; }
    public string Notes { get; set; }
}