namespace ArERP.Models.Entity.Finance;

public class JournalEntry
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public ICollection<JournalEntryLine> Lines { get; set; }
}
