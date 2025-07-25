namespace ArERP.Models.Entity;

public class Permission
{
    public int Id { get; set; }
    public string Module { get; set; }
    public string Action { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}