using ArERP.Areas.Inventory.Models;

namespace ArERP.Areas.Inventory.Repository;

public interface IInventoryBalanceRepository
{
    List<InventoryBalance> GetAllInventoryBalances();
    List<InventoryBalance> GetInventoryBalanceByWarehouseId(int id);
    List<InventoryBalance> GetInventoryBalanceByItemId(int id);
}