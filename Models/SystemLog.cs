using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models;

public class SystemLog
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime RecordTime { get; set; }
    public string? SourceAddress { get; set; }
    public string Content { get; set; }
    public LogLevel Level { get; set; }
}