using System.Collections.Generic;
using ArERP.Models.Entity;

namespace ArERP.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<EmployeeEntity> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public void AddEmployee(EmployeeEntity employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
    }
}