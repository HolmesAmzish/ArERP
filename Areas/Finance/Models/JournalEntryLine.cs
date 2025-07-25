namespace ArERP.Models.Entity.Finance;

public class JournalEntryLine
{
    public int Id { get; set; }

    public int JournalEntryId { get; set; }
    public JournalEntry Entry { get; set; }

    public string AccountCode { get; set; }   // E.g., "5001" = Materials
    public decimal Debit { get; set; }        // E.g., 1000.00
    public decimal Credit { get; set; }       // E.g., 0.00
}
