using ArERP.Models.Entity;
using ArERP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Controllers;

public class DepartmentController : Controller
{
    private readonly IDerpartmentRepository _derpartmentRepository;

    public DepartmentController(IDerpartmentRepository derpartmentRepository)
    {
        this._derpartmentRepository = derpartmentRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var departments = _derpartmentRepository.GetAllDepartments();
        return View(departments);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Department department)
    {
        
        if (!ModelState.IsValid)
        {
            return View(department);
        }

        _derpartmentRepository.AddDepartment(department);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Detail()
    {
        return View();
    }
}