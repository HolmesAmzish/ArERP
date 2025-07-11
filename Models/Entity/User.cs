using System.ComponentModel.DataAnnotations;

namespace ArERP.Models.Entity;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    
}

