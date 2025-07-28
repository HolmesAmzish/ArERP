using ArERP.Areas.HumanResource.Models;

namespace ArERP.Areas.HumanResource.Repository;

public interface IEmployeeRepository
{
    List<Employee> GetAllEmployees();
    Employee? GetEmployeeById(int id);
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
}