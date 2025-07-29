using ArERP.Areas.Inventory.Models;
using ArERP.Data;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.Inventory.Repository.Impl;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<Transaction> GetAllTransactions() =>
        _context.Transactions
            .Include(t => t.Lines)
            .ThenInclude(l => l.Item)
            .ToList();
    public Transaction? GetTransactionById(int id) =>
        _context.Transactions
            .FirstOrDefault(t => t.Id == id);

    public void AddTransaction(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public void RemoveTransaction(Transaction transaction)
    {
        _context.Transactions.Remove(transaction);
        _context.SaveChanges();
    }
}