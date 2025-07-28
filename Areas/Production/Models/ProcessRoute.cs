using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Production.Models;

public class ProcessRoute
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    
    // Materials
    public int BillOfMaterialId { get; set; }
    [ForeignKey("BillOfMaterialId")]
    public Bom Bom { get; set; }
    
    // Process route steps
    public ICollection<ProcessRouteLines> ProcessRouteLines { get; set; }
}