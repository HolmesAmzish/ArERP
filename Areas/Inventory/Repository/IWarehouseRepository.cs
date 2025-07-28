using ArERP.Areas.Inventory.Models;

namespace ArERP.Areas.Inventory.Repository;

public interface IWarehouseRepository
{
    List<Warehouse> GetAllWarehouses();
    Warehouse? GetWarehouseById(int id);
    void AddWarehouse(Warehouse warehouse);
    void RemoveWarehouse(Warehouse warehouse);
    void UpdateWarehouse(Warehouse warehouse);
}