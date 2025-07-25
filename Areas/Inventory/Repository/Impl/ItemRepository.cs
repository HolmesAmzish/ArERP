using ArERP.Areas.Inventory.Models;
using ArERP.Repository;

namespace ArERP.Areas.Inventory.Repository.Impl;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        this._context = context;
    }
    
    public List<Item> GetAllItems() => _context.Items.ToList();
    public Item? GetItemById(int id) => _context.Items.FirstOrDefault(i => i.Id == id);

    public void AddItem(Item item)
    {
        _context.Items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _context.Items.Remove(item);
    }
}