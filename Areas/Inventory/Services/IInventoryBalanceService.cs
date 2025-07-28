using ArERP.Areas.Inventory.Models;

namespace ArERP.Areas.Inventory.Services;

public interface IInventoryBalanceService
{
    public List<InventoryBalance> GetAllInventoryBalances();
    public List<InventoryBalance> GetInventoryBalancesByWarehouseId(int id);
    public List<InventoryBalance> GetInventoryyBalancesByItemId(int id);
}