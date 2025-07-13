using System.ComponentModel.DataAnnotations;

namespace ArERP.Models.Entity;

public class EmployeeSeparation
{
    // db field
    [Key]
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public ProcessStatus Status { get; set; } = ProcessStatus.Pending;
    
    // info field
    public string EmployeeName { get; set; }
    public string? SeparationReason { get; set; }
    public DateTime SeparationDate { get; set; }
}