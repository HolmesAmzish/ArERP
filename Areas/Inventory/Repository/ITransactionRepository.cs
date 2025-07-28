using ArERP.Areas.Inventory.Models;

namespace ArERP.Areas.Inventory.Repository;

public interface ITransactionRepository
{
    List<Transaction> GetAllTransactions();
    Transaction? GetTransactionById(int id);
    void AddTransaction(Transaction transaction);
    void RemoveTransaction(Transaction transaction);
}