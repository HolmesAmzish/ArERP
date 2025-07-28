using ArERP.Areas.HumanResource.Models;
using ArERP.Data;

namespace ArERP.Areas.HumanResource.Repositories.Impl;

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

    public Department? GetDepartmentById(int id)
    {
        return _context.Departments.FirstOrDefault(d => d.Id == id);
    }

    public void UpdateDepartment(Department department)
    {
        _context.Departments.Update(department);
        _context.SaveChanges();
    }
}
