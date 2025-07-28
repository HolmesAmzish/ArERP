using ArERP.Areas.Inventory.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Areas.Inventory.Controllers;

[Area("Inventory")]
public class ItemController : Controller
{
    private readonly IItemRepository _itemRepository;

    public ItemController(IItemRepository itemRepository)
    {
        this._itemRepository = itemRepository;
    }
    
    // GET: /Inventory/Item
    public IActionResult Index()
    {
        var items = _itemRepository.GetAllItems();
        return View(items);
    }
}