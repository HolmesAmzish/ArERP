using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Finance.Models;

public class JournalEntryLine
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int JournalEntryId { get; set; }
    [ForeignKey("JournalEntryId")]
    public JournalEntry Entry { get; set; }

    public string AccountCode { get; set; }   // E.g., "5001" = Materials
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Debit { get; set; }        // E.g., 1000.00
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Credit { get; set; }       // E.g., 0.00
}
