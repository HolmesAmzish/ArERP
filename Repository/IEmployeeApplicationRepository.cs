using ArERP.Models.Entity;

namespace ArERP.Repository;

public interface IEmployeeApplicationRepository
{
    List<EmployeeApplication> GetAllEmployeeApplications();
    EmployeeApplication? GetEmployeeApplicationById(int id);
    void AddEmployeeApplication(EmployeeApplication employeeApplication);
    void UpdateEmployeeApplication(EmployeeApplication employeeApplication);
}
