using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.HumanResource.Repository;
using ArERP.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Areas.HumanResource.Controllers;
[Area("HumanResource")]
public class EmployeeApplicationController : Controller
{
    private readonly IEmployeeApplicationRepository _employeeApplicationRepository;
    private readonly IDerpartmentRepository _derpartmentRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeApplicationController(
        IEmployeeApplicationRepository employeeApplicationRepository,
        IDerpartmentRepository derpartmentRepository,
        IEmployeeRepository employeeRepository)
    {
        this._employeeApplicationRepository = employeeApplicationRepository;
        this._derpartmentRepository = derpartmentRepository;
        this._employeeRepository = employeeRepository;
    }

    
    // GET: EmployeeApplication/Index
    [HttpGet]
    public IActionResult Index()
    {
        var employeeApplications = _employeeApplicationRepository.GetAllEmployeeApplications();
        return View(employeeApplications);
    }
    
    // GET: EmployeeApplication/Create
    [HttpGet]
    public IActionResult Create()
    {
        var departments = _derpartmentRepository.GetAllDepartments();
        if (departments == null)
        {
            throw new Exception("Departments not found");
        }

        ViewBag.Departments = departments;
        return View();
    }

    // POST: EmployeeApplication/Create
    [HttpPost]
    public IActionResult Create(EmployeeApplication employeeApplication)
    {
        // if (ModelState.IsValid)
        // {
            _employeeApplicationRepository.AddEmployeeApplication(employeeApplication);
            return RedirectToAction(nameof(Index));
        // }

        // ViewBag.Departments = _derpartmentRepository.GetAllDepartments();
        //
        // ViewData["ErrorMessage"] = "请检查输入项，有错误未通过验证。";
        // return View(employeeApplication);
    }

    // GET: EmployeeApplication/Details/{id}
    [HttpGet]
    public IActionResult Details(int id)
    {
        var application = _employeeApplicationRepository.GetEmployeeApplicationById(id);
        if (application == null)
        {
            return NotFound();
        }
        return View(application);
    }

    // GET: EmployeeApplication/Edit/{id}
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var application = _employeeApplicationRepository.GetEmployeeApplicationById(id);
        if (application == null)
        {
            return NotFound();
        }
        return View(application);
    }

    // POST: EmployeeApplication/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EmployeeApplicationUpdateDto updateDto)
    {
        if (updateDto.Id == null)
        {
        return NotFound();
        }
        
        var application = _employeeApplicationRepository.GetEmployeeApplicationById(updateDto.Id);
        if (application == null)
        {
            return NotFound();
        }
        application.Status = updateDto.Status;
        application.Approver = updateDto.Approver;
        application.ApprovalNote = updateDto.ApprovalNote;
        _employeeApplicationRepository.UpdateEmployeeApplication(application);

        if (updateDto.Status == ProcessStatus.Approved)
        {
            var newEmployee = new Employee
            {
                DepartmentId = application.DepartmentId,
                EmployeeName = application.Name,
                Gender = application.Gender,
                BirthDate = application.DateOfBirth,
                Email = application.Email,
                Phone = application.Phone
            };
            
            _employeeRepository.AddEmployee(newEmployee);
        }
        
        return RedirectToAction(nameof(Index));
    }
}
