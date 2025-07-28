using ArERP.Areas.HumanResource.Models;
using ArERP.Data;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.HumanResource.Repositories.Impl;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Employee> GetAllEmployees()
    {
        return _context.Employees
            .Include(e => e.Department)
            .ToList();
    }

    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public Employee GetEmployeeById(int id)
    {
        return _context.Employees.FirstOrDefault(m => m.Id == id);
    }

    public void UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }
}
