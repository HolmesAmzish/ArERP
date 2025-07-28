using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Production.Models;

public class ProcessRouteLines
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int RouteId { get; set; }
    [ForeignKey("RouteId")]
    public ProcessRoute Route { get; set; }
    
    public int ProcessOperationId { get; set; }
    [ForeignKey("ProcessOperationId")]
    public ProcessOperation ProcessOperation { get; set; }
    
    public int Sequence { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal StandardTime { get; set; }
}