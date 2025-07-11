using ArERP.Models.Entity;

namespace ArERP.Repository;

public class DepartmentRepository : IDerpartmentRepository
{
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Department> GetAllDepartments()
    {
        return _context.Departments.ToList();
    }

    public void AddDepartment(Department department)
    {
        _context.Departments.Add(department);
        _context.SaveChanges();
    }
}