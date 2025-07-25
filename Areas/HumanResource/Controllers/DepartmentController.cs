using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.HumanResource.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArERP.Areas.HumanResource.Controllers;

[Area("HumanResource")]
public class DepartmentController : Controller
{
    private readonly IDerpartmentRepository _derpartmentRepository;

    public DepartmentController(IDerpartmentRepository derpartmentRepository)
    {
        this._derpartmentRepository = derpartmentRepository;
    }

    // GET: /HumanResource/Department
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

    // GET: /HumanResource/Department/Details/{id}
    [HttpGet]
    public IActionResult Details(int id)
    {
        var department = _derpartmentRepository.GetDepartmentById(id);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var department = _derpartmentRepository.GetDepartmentById(id);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,DepartmentName,CreationDate,Deleted")] Department department)
    {
        if (id != department.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _derpartmentRepository.UpdateDepartment(department);
            }
            catch
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }
}
