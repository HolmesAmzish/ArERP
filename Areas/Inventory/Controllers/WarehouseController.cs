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
        var warehouses = _warehouseRepository.GetAllWarehouses();
        return View(warehouses);
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
    
    // GET: /Inventory/Warehouse/Details/{id}
    [HttpGet]
    public IActionResult Details(int id)
    {
        var warehouse = _warehouseRepository.GetWarehouseById(id);
        if (warehouse == null)
        {
            return NotFound();
        }

        return View(warehouse);
    }
}