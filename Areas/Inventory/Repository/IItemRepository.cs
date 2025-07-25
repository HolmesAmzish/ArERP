using ArERP.Areas.Inventory.Models;

namespace ArERP.Areas.Inventory.Repository;

public interface IItemRepository
{
    List<Item> GetAllItems();
    Item GetItemById(int id);
    void AddItem(Item item);
    void RemoveItem(Item item);
}