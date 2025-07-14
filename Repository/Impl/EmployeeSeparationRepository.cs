using ArERP.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Repository.Impl;

public class EmployeeSeparationRepository : IEmployeeSeparationRepository
{
    private readonly AppDbContext _context;

    public EmployeeSeparationRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public List<EmployeeSeparation> GetAllEmployeeSeparations()
    {
        return _context.EmployeeSeparations
            .Include(e => e.EmployeeInfo)
            .ToList();
    }

    public void AddEmployeeSeparation(EmployeeSeparation employeeSeparation)
    {
        _context.EmployeeSeparations.Add(employeeSeparation);
        _context.SaveChanges();
    }

    public EmployeeSeparation? GetEmployeeSeparationById(int id)
    {
        return _context.EmployeeSeparations
            .Include(e => e.EmployeeInfo)
            .FirstOrDefault(e => e.Id == id);
    }

    public void UpdateEmployeeSeparation(EmployeeSeparation employeeSeparation)
    {
        _context.EmployeeSeparations.Update(employeeSeparation);
        _context.SaveChanges();
    }
}
