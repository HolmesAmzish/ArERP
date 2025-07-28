using ArERP.Areas.Inventory.Models;
using ArERP.Areas.Inventory.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Areas.Inventory.Controllers;

[ApiController]
[Route("api/[area]/[controller]")]
[Area("Inventory")]
public class InventoryBalanceController : ControllerBase
{
    private readonly IInventoryBalanceService _inventoryBalanceService;

    public InventoryBalanceController(IInventoryBalanceService inventoryBalanceService)
    {
        _inventoryBalanceService = inventoryBalanceService;
    }
    
    // GET: api/Inventory/InventoryBalance
    [HttpGet]
    public ActionResult<IEnumerable<InventoryBalance>> GetAll()
    {
        try
        {
            var inventoryBalances = _inventoryBalanceService.GetAllInventoryBalances();
            if (inventoryBalances == null || !inventoryBalances.Any())
            {
                return NotFound("No inventory balances found");
            }
            return Ok(inventoryBalances);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}