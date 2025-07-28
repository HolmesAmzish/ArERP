using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models.Entity;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }
    
    // Extend information
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public DateTime CreateAt { get; set; }
    public bool IsDelete { get; set; }
}

