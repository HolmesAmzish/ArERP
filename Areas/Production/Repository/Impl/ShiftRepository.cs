using ArERP.Areas.Production.Models;
using ArERP.Data;

namespace ArERP.Areas.Production.Repository.Impl;

public class ShiftRepository : IShiftRepository
{
    private readonly AppDbContext _context;

    public ShiftRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<Shift> GetAllShifts() =>
        _context.Shifts
            .ToList();
}