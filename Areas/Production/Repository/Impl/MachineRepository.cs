using ArERP.Data;
using ArERP.Areas.Production.Models;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.Production.Repository.Impl;

public class MachineRepository : IMachineRepository
{
    private readonly AppDbContext _context;

    public MachineRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<Machine> GetAllMachines() =>
        _context.Machines
            .Include(m => m.Workshop)
            .ToList();

    public List<Machine> GetMachinesByWorkshopId(int workshopId) =>
        _context.Machines
            .Include(m => m.Workshop)
            .Where(m => m.WorkshopId == workshopId)
            .ToList();
}