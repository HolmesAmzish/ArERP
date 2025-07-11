using ArERP.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArERP.Controllers;

public class EmployeeApplicationController : Controller
{
    private readonly IEmployeeApplicationRepository _employeeApplicationRepository;

    public EmployeeApplicationController(IEmployeeApplicationRepository employeeApplicationRepository)
    {
        this._employeeApplicationRepository = employeeApplicationRepository;
    }
    
    // GET: EmployeeApplication/Index
    [HttpGet]
    public IActionResult Index()
    {
        var employeeApplications = _employeeApplicationRepository.GetAllEmployeeApplications();
        return View(employeeApplications);
    }
    
    // G
    
}
