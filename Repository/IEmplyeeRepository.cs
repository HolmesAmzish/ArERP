using System.Collections.Generic;
using ArERP.Models.Entity;

namespace ArERP.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeEntity> GetAllEmployees();
        void AddEmployee(EmployeeEntity employee);
    }
}
