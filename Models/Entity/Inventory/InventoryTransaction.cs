using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Models.Enum;

namespace ArERP.Models.Entity.Inventory;

public class InventoryTransaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
    public InventoryTransactionType Type { get; set; }

    // public string? ReferenceType { get; set; }
    // public int? ReferenceId { get; set; }

    public ICollection<TransactionLine> Lines { get; set; } = new List<TransactionLine>();
}