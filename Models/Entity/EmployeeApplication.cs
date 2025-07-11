using System.ComponentModel.DataAnnotations;

namespace ArERP.Models.Entity;

public class EmployeeApplication
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Gender { get; set; } = "male";
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
    [Required]
    public string NationalId { get; set; }
    [Required]
    public string Phone { get; set; }
    public string? Email { get; set; }
    public int DepartmentId { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
    public string? Approver { get; set; }
    public string? ApprovalNote { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
    public DateTime? ApprovalDate { get; set; }
    public bool Deleted { get; set; } = false;
}