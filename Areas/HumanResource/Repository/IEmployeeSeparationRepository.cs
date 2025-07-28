using ArERP.Areas.HumanResource.Models;

namespace ArERP.Areas.HumanResource.Repository;

public interface IEmployeeSeparationRepository
{
    List<EmployeeSeparation> GetAllEmployeeSeparations();
    EmployeeSeparation? GetEmployeeSeparationById(int id);
    void AddEmployeeSeparation(EmployeeSeparation employeeSeparation);
    void UpdateEmployeeSeparation(EmployeeSeparation employeeSeparation);
    List<SeparationStatistics> GetSeparationStatistics(DateTime? startDate, DateTime? endDate, int? departmentId);
}

public class SeparationStatistics
{
    public string DepartmentName { get; set; }
    public int SeparationCount { get; set; }
}
