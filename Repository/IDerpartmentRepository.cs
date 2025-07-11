using ArERP.Models.Entity;

namespace ArERP.Repository;

public interface IDerpartmentRepository
{
    List<Department> GetAllDepartments();
    void AddDepartment(Department department);
}