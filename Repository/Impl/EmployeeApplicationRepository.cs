using ArERP.Models.Entity;

namespace ArERP.Repository;

public class EmployeeApplicationRepository : IEmployeeApplicationRepository
{
    private readonly AppDbContext _context;

    public EmployeeApplicationRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public List<EmployeeApplication> GetAllEmployeeApplications()
    {
        return _context.EmployeeApplications.ToList();
    }

    public void AddEmployeeApplication(EmployeeApplication employeeApplication)
    {
        _context.EmployeeApplications.Add(employeeApplication);
        _context.SaveChanges();
    }
}