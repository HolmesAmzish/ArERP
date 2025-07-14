using ArERP.Models.Entity;

namespace ArERP.Repository;

public interface IEmployeeSeparationRepository
{
    List<EmployeeSeparation> GetAllEmployeeSeparations();
    EmployeeSeparation? GetEmployeeSeparationById(int id);
    void AddEmployeeSeparation(EmployeeSeparation employeeSeparation);
    void UpdateEmployeeSeparation(EmployeeSeparation employeeSeparation);
}
