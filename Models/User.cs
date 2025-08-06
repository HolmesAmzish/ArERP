using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Enum;

namespace ArERP.Models;

public class User
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
    
    public ICollection<UserRole> UserRoles { get; set; }
    
    // Extend information
    public string? Email { get; set; }
    public Gender? Gender { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime CreateAt { get; set; } = DateTime.Now;

    public bool IsDelete { get; set; } = false;
}
