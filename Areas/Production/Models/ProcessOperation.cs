using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Production.Models;

public class ProcessOperation
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Code { get; set; }
    
    public string Name { get; set; }
    
    public int WorkshopId { get; set; }
    [ForeignKey("WorkshopId")]
    public Workshop Workshop { get; set; }
}