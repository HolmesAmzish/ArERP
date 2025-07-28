using ArERP.Areas.HumanResource.Models;

namespace ArERP.Areas.HumanResource.Repository;

public interface IDerpartmentRepository
{
    List<Department> GetAllDepartments();
    Department? GetDepartmentById(int id);
    void AddDepartment(Department department);
    void UpdateDepartment(Department department);
}
