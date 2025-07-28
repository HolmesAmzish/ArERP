using ArERP.Areas.Inventory.Models;
using ArERP.Data;

namespace ArERP.Areas.Inventory.Repository.Impl;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly AppDbContext _context;

    public WarehouseRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<Warehouse> GetAllWarehouses() => _context.Warehouses.ToList();
    public Warehouse? GetWarehouseById(int id) => _context.Warehouses.FirstOrDefault(w => w.Id == id);

    public void AddWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Add(warehouse);
    }

    public void RemoveWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Remove(warehouse);
    }

    public void UpdateWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Update(warehouse);
        _context.SaveChanges();
    }
}