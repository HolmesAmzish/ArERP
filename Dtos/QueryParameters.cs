namespace ArERP.Dtos;

public class QueryParameters
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;

    public string SortField { get; set; } = "Id";
    public bool SortDescending { get; set; } = false;

    public string SearchKeyword { get; set; } = "";
}
