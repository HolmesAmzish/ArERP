using System.Collections.Generic;
using ArERP.Models.Entity;

namespace ArERP.Repository;

public interface IEmployeeRepository
{
    List<Employee> GetAllEmployees();
    void AddEmployee(Employee employee);
    Employee GetEmployeeById(int id);
    void UpdateEmployee(Employee employee);
}