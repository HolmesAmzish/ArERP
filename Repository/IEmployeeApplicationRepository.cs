using ArERP.Models.Entity;

namespace ArERP.Repository;

public interface IEmployeeApplicationRepository
{
    List<EmployeeApplication> GetAllEmployeeApplications();
    void AddEmployeeApplication(EmployeeApplication employeeApplication);
}