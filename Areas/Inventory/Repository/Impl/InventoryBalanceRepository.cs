using ArERP.Areas.Inventory.Models;
using ArERP.Data;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.Inventory.Repository.Impl;

public class InventoryBalanceRepository : IInventoryBalanceRepository
{
    private readonly AppDbContext _context;

    public InventoryBalanceRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<InventoryBalance> GetAllInventoryBalances()
    {
        return _context.InventoryBalances
            .Include(ib => ib.Item)
            .Include(ib => ib.Warehouse)
            .ToList();
    }

    public List<InventoryBalance> GetInventoryBalanceByWarehouseId(int id)
    {
        return _context.InventoryBalances
            .Where(ib => ib.WarehouseId == id)
            .Include(ib => ib.Item)
            .Include(ib => ib.Warehouse)
            .ToList();
    }

    public List<InventoryBalance> GetInventoryBalanceByItemId(int id)
    {
        return _context.InventoryBalances
            .Where(ib => ib.ItemId == id)
            .Include(ib => ib.Item)
            .Include(ib => ib.Warehouse)
            .ToList();
    }
}