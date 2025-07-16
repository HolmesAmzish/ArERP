using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models.Entity;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    
    public int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public DateTime CreateAt { get; set; }
    public bool IsDelete { get; set; }
}

