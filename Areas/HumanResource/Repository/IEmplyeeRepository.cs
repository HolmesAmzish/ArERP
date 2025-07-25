using ArERP.Areas.HumanResource.Models;

namespace ArERP.Areas.HumanResource.Repositories;

public interface IEmployeeRepository
{
    List<Employee> GetAllEmployees();
    void AddEmployee(Employee employee);
    Employee GetEmployeeById(int id);
    void UpdateEmployee(Employee employee);
}