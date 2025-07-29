namespace ArERP.Dtos;

public class ProductionTransactionStats
{
    public string Production { get; set; }
    public List<ProductionData> Data { get; set; }
}

public class ProductionData
{
    public DateTime RecordTime { get; set; }
    public decimal Quantity { get; set; }
}