using ArERP.Models.Enum;

namespace ArERP.Areas.HumanResource.Models;

public class EmployeeApplicationUpdateDto
{
    public int Id { get; set; }
    public ProcessStatus Status { get; set; }
    public string Approver { get; set; }
    public string ApprovalNote { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public bool Deleted { get; set; }
}
