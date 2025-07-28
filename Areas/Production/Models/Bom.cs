using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Areas.Inventory.Models;

namespace ArERP.Areas.Production.Models;

public class Bom
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public ICollection<BomLines> BomLines { get; set; }
}