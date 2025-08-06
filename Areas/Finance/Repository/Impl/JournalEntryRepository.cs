using ArERP.Areas.Finance.Models;
using ArERP.Data;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.Finance.Repository.Impl;

public class JournalEntryRepository : IJournalEntryRepository
{
    private readonly AppDbContext _context;

    public JournalEntryRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<JournalEntry>> GetAllEntryAsync() =>
        _context.JournalEntries.Include(e => e.Lines).ToListAsync();

    public Task<JournalEntry> GetEntryByIdAsync(int id) =>
        _context.JournalEntries.Include(e => e.Lines).FirstOrDefaultAsync(e => e.Id == id);

    public async Task AddEntryAsync(JournalEntry entry)
    {
        await _context.JournalEntries.AddAsync(entry);
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
