using ArERP.Areas.HumanResource.Models;

namespace ArERP.Areas.HumanResource.Repository;

public interface IEmployeeApplicationRepository
{
    List<EmployeeApplication> GetAllEmployeeApplications();
    EmployeeApplication? GetEmployeeApplicationById(int id);
    void AddEmployeeApplication(EmployeeApplication employeeApplication);
    void UpdateEmployeeApplication(EmployeeApplication employeeApplication);
}
