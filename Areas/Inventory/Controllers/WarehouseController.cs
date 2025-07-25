using ArERP.Areas.Inventory.Models;
using ArERP.Areas.Inventory.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Areas.Inventory.Controllers;

[Area("Inventory")]
public class WarehouseController : Controller
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseController(IWarehouseRepository warehouseRepository)
    {
        this._warehouseRepository = warehouseRepository;
    }
    
    // GET: /Inventory/Warehouse
    public IActionResult Index()
    {
        return View(_warehouseRepository.GetAllWarehouses());
    }
    
    // GET: /Inventory/Warehouse/Create
    [HttpGet]
    public IActionResult Create() => View();
    
    // POST: /Inventory/Warehouse/Create
    [HttpPost]
    public IActionResult Create(Warehouse warehouse)
    {
        _warehouseRepository.AddWarehouse(warehouse);
        return RedirectToAction(nameof(Index));
    }
}