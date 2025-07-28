using ArERP.Areas.Production.Models;
using ArERP.Data;

namespace ArERP.Areas.Production.Repository.Impl;

public class WorkshopRepository : IWorkshopRepository
{
    private readonly AppDbContext _context;

    public WorkshopRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<Workshop> GetAllWorkshops() => 
        _context.Workshops
            .ToList();
}