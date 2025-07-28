using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Areas.Production.Enum;

namespace ArERP.Areas.Production.Models;

public class Machine
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Code { get; set; }
    
    public string Name { get; set; }
    
    public MachineStatus Status { get; set; }
    
    public int WorkshopId { get; set; }
    [ForeignKey("WorkshopId")]
    public Workshop Workshop { get; set; }
}