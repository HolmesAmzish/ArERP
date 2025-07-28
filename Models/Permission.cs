using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models.Entity;

public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Module { get; set; }
    public string Action { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}