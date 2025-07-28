using ArERP.Areas.Inventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArERP.Areas.Inventory.Controllers;

[Area("Inventory")]
public class HomeController : Controller
{
    private readonly IInventoryBalanceService _inventoryBalanceService;

    public HomeController(IInventoryBalanceService inventoryBalanceService)
    {
        this._inventoryBalanceService = inventoryBalanceService;
    }
    
    public IActionResult Index()
    {
        var inventoryBalances = _inventoryBalanceService.GetAllInventoryBalances();
        return View(inventoryBalances);
    }
}