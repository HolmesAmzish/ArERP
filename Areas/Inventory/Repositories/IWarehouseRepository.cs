using ArERP.Models.Entity.Inventory;

namespace ArERP.Repository;

public interface IWarehouseRepository
{
    List<Warehouse> GetAllWarehouses();
    Warehouse? GetWarehouseById(int id);
    void AddWarehouse(Warehouse warehouse);
    void DeleteWarehouse(Warehouse warehouse);
}