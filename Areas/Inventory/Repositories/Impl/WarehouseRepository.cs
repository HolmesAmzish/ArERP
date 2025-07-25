using ArERP.Models.Entity.Inventory;

namespace ArERP.Repository.Impl;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly AppDbContext _context;

    public WarehouseRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    
    public List<Warehouse> GetAllWarehouses()
    {
        List<Warehouse> allWarehouses = _context.Warehouses.ToList();
        return allWarehouses;
    }

    public Warehouse? GetWarehouseById(int id)
    {
        return _context.Warehouses.FirstOrDefault(w => w.Id == id);
    }

    public void AddWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Add(warehouse);
    }

    public void DeleteWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Remove(warehouse);
    }
}