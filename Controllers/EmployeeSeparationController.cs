using ArERP.Models;
using ArERP.Models.Entity;
using ArERP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Controllers;

public class EmployeeSeparationController : Controller
{
    private readonly IEmployeeSeparationRepository _employeeSeparationRepository;
    private readonly IDerpartmentRepository _derpartmentRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeSeparationController(
        IEmployeeSeparationRepository employeeSeparationRepository,
        IDerpartmentRepository derpartmentRepository,
        IEmployeeRepository employeeRepository)
    {
        _employeeSeparationRepository = employeeSeparationRepository;
        _derpartmentRepository = derpartmentRepository;
        _employeeRepository = employeeRepository;
    }

    // GET: EmployeeSeparation/Index
    [HttpGet]
    public IActionResult Index()
    {
        var employeeSeparations = _employeeSeparationRepository.GetAllEmployeeSeparations();
        return View(employeeSeparations);
    }

    // GET: EmployeeSeparation/Create
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Employees = _employeeRepository.GetAllEmployees();
        return View();
    }

    // POST: EmployeeSeparation/Create
    [HttpPost]
    public IActionResult Create(EmployeeSeparation employeeSeparation)
    {
        _employeeSeparationRepository.AddEmployeeSeparation(employeeSeparation);
        return RedirectToAction(nameof(Index));
    }

    // GET: EmployeeSeparation/Details/{id}
    [HttpGet]
    public IActionResult Details(int id)
    {
        var separation = _employeeSeparationRepository.GetEmployeeSeparationById(id);
        if (separation == null)
        {
            return NotFound();
        }
        return View(separation);
    }

    // GET: EmployeeSeparation/Edit/{id}
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var separation = _employeeSeparationRepository.GetEmployeeSeparationById(id);
        if (separation == null)
        {
            return NotFound();
        }
        return View(separation);
    }

    // POST: EmployeeSeparation/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, EmployeeSeparation separation)
    {
        if (separation.Id == null)
        {
            return NotFound();
        }
        
        var existingSeparation = _employeeSeparationRepository.GetEmployeeSeparationById(separation.Id);
        if (existingSeparation == null)
        {
            return NotFound();
        }

        existingSeparation.Status = separation.Status;
        existingSeparation.Approver = separation.Approver;
        existingSeparation.ApprovalNote = separation.ApprovalNote;
        _employeeSeparationRepository.UpdateEmployeeSeparation(existingSeparation);

        return RedirectToAction(nameof(Index));
    }
}
