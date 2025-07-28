using ArERP.Areas.HumanResource.Models;
using ArERP.Data;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.HumanResource.Repository.Impl;

public class EmployeeApplicationRepository : IEmployeeApplicationRepository
{
    private readonly AppDbContext _context;

    public EmployeeApplicationRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public List<EmployeeApplication> GetAllEmployeeApplications()
    {
        return _context.EmployeeApplications
            .Include(e => e.Department)
            .ToList();
    }

    public void AddEmployeeApplication(EmployeeApplication employeeApplication)
    {
        _context.EmployeeApplications.Add(employeeApplication);
        _context.SaveChanges();
    }

    public EmployeeApplication? GetEmployeeApplicationById(int id)
    {
        return _context.EmployeeApplications
            .Include(e => e.Department)
            .FirstOrDefault(e => e.Id == id);
    }

    public void UpdateEmployeeApplication(EmployeeApplication employeeApplication)
    {
        _context.EmployeeApplications.Update(employeeApplication);
        _context.SaveChanges();
    }
}
