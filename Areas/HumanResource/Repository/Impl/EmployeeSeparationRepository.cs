using ArERP.Areas.HumanResource.Models;
using ArERP.Repository;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.HumanResource.Repositories.Impl;

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

    public List<SeparationStatistics> GetSeparationStatistics(DateTime? startDate, DateTime? endDate, int? departmentId)
    {
        var query = _context.EmployeeSeparations
            .Include(e => e.EmployeeInfo)
            .ThenInclude(e => e.Department)
            .AsQueryable();

        if (startDate.HasValue)
            query = query.Where(s => s.SeparationDate >= startDate.Value);
        
        if (endDate.HasValue)
            query = query.Where(s => s.SeparationDate <= endDate.Value);
        
        if (departmentId.HasValue)
            query = query.Where(s => s.EmployeeInfo.DepartmentId == departmentId.Value);

        return query
            .GroupBy(s => s.EmployeeInfo.Department.DepartmentName)
            .Select(g => new SeparationStatistics
            {
                DepartmentName = g.Key,
                SeparationCount = g.Count()
            })
            .ToList();
    }
}
