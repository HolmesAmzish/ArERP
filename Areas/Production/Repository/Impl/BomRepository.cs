using ArERP.Areas.Production.Models;
using ArERP.Data;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.Production.Repository.Impl;

public class BomRepository : IBomRepository
{
    private readonly AppDbContext _context;

    public BomRepository(AppDbContext context)
    {
        this._context = context;
    }

    public List<Bom> GetAllBom() =>
        _context.Bom
            .Include(b => b.BomLines)
            .ThenInclude(b => b.Material)
            .ToList();

    public Bom? GetBomById(int id) =>
        _context.Bom
            .Where(b => b.Id == id)
            .Include(b => b.BomLines)
            .ThenInclude(bl => bl.Material)
            .FirstOrDefault();


    public void AddBom(Bom bom)
    {
        _context.Bom.Add(bom);
        _context.SaveChanges();
    }

    public void RemoveBom(Bom bom)
    {
        _context.Bom.Remove(bom);
        _context.SaveChanges();
    }

    public void UpdateBom(Bom bom)
    {
        _context.Bom.Update(bom);
        _context.SaveChanges();
    }
}