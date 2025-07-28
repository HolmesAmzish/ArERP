using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Production.Models;

public class Shift
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    
    public bool IsNightShift { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public decimal WorkingHours { get; set; }
    
    public bool IsActive { get; set; }
}