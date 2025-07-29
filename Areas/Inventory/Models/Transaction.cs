using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Inventory.Models;

public class Transaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
    
    public TransactionType Type { get; set; }
    public int? SourceId { get; set; }

    public ICollection<TransactionLine> Lines { get; set; } = new List<TransactionLine>();
    
}