using ArERP.Models.Entity;

namespace ArERP.Repository;

public interface IDerpartmentRepository
{
    List<Department> GetAllDepartments();
    Department? GetDepartmentById(int id);
    void AddDepartment(Department department);
    void UpdateDepartment(Department department);
}
