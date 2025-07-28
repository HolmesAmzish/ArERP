using ArERP.Areas.Inventory.Models;
using ArERP.Areas.Inventory.Repository;

namespace ArERP.Areas.Inventory.Services.Impl;

public class InventoryBalanceService : IInventoryBalanceService
{
    private readonly IInventoryBalanceRepository _inventoryBalanceRepo;

    public InventoryBalanceService(IInventoryBalanceRepository inventoryBalanceRepo)
    {
        this._inventoryBalanceRepo = inventoryBalanceRepo;
    }

    public List<InventoryBalance> GetAllInventoryBalances()
    {
        return _inventoryBalanceRepo.GetAllInventoryBalances();
    }

    public List<InventoryBalance> GetInventoryBalancesByWarehouseId(int id)
    {
        return _inventoryBalanceRepo.GetInventoryBalanceByWarehouseId(id);
    }

    public List<InventoryBalance> GetInventoryyBalancesByItemId(int id)
    {
        return _inventoryBalanceRepo.GetInventoryBalanceByItemId(id);
    }
}