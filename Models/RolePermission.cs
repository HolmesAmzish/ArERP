using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models.Entity;

public class RolePermission
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
    
    public int PermissionId { get; set; }
    [ForeignKey("PermissionId")]
    public Permission Permission { get; set; }
}