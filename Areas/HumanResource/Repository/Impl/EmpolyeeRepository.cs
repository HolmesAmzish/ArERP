using ArERP.Areas.HumanResource.Models;
using ArERP.Data;
using Microsoft.EntityFrameworkCore;

namespace ArERP.Areas.HumanResource.Repository.Impl;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;
    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Employee> GetAllEmployees() =>
        _context.Employees
            .Include(e => e.Department)
            .ToList();

    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public Employee? GetEmployeeById(int id) =>
        _context.Employees
            .Include(e => e.Department)
            .FirstOrDefault(m => m.Id == id);

    public void UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }
}
