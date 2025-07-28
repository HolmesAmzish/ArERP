using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Finance.Models;

public class JournalEntry
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public ICollection<JournalEntryLine> Lines { get; set; }
}
