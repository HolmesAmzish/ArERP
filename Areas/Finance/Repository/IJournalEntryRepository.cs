using ArERP.Areas.Finance.Models;

namespace ArERP.Areas.Finance.Repository;

public interface IJournalEntryRepository
{
    Task<List<JournalEntry>> GetAllEntryAsync();
    Task<JournalEntry> GetEntryByIdAsync(int id);
    Task AddEntryAsync(JournalEntry entry);
    Task SaveChangesAsync();
}