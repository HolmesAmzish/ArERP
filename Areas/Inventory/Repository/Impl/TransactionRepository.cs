using ArERP.Areas.Inventory.Models;
using ArERP.Data;

namespace ArERP.Areas.Inventory.Repository.Impl;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<Transaction> GetAllTransactions() => _context.Transactions.ToList();
    public Transaction? GetTransactionById(int id) => _context.Transactions.FirstOrDefault(t => t.Id == id);

    public void AddTransaction(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
    }

    public void RemoveTransaction(Transaction transaction)
    {
        _context.Transactions.Remove(transaction);
    }
}