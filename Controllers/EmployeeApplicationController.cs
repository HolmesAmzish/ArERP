using ArERP.Models.Dto;
using ArERP.Models.Entity;
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
    
    // GET: EmployeeApplication/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: EmployeeApplication/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EmployeeApplication employeeApplication)
    {
        if (ModelState.IsValid)
        {
            _employeeApplicationRepository.AddEmployeeApplication(employeeApplication);
            return RedirectToAction(nameof(Index));
        }
        return View(employeeApplication);
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
    public IActionResult Edit([FromBody] EmployeeApplicationUpdateDto updateDto)
    {
        if (updateDto.Id == null)
        {
        return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var existingApplication = _employeeApplicationRepository.GetEmployeeApplicationById(updateDto.Id);
                if (existingApplication == null)
                {
                    return NotFound();
                }
                existingApplication.Status = updateDto.Status;
                existingApplication.Approver = updateDto.Approver;
                existingApplication.ApprovalNote = updateDto.ApprovalNote;
                _employeeApplicationRepository.UpdateEmployeeApplication(existingApplication);
            }
            catch
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return BadRequest(ModelState);
    }
}
