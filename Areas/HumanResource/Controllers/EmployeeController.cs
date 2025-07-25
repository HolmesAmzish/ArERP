using Microsoft.AspNetCore.Mvc;
using ArERP.Areas.HumanResource.Models;
using ArERP.Areas.HumanResource.Repositories;

namespace ArERP.Areas.HumanResource.Controllers;
[Area("HumanResource")]
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        this._employeeRepository = employeeRepository;
    }

    // GET: /Employee
    public IActionResult Index()
    {
        var employees = _employeeRepository.GetAllEmployees();
        return View(employees);
    }

    // GET: /Employee/Add
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Employee/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employee employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }

        _employeeRepository.AddEmployee(employee);
        return RedirectToAction(nameof(Index));
    }
    
    // GET: /Employee/Details/{id}
    [HttpGet]
    public IActionResult Details(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);
        return View(employee);
    }
    
    // Get: /Employee/Edit/{id}
    public IActionResult Edit(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);
        return View(employee);
    }
    
    // POST: /Employee/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(
        int id,
        [Bind("Id,EmployeeName,Gender,BirthDate,Email,Phone,HireDate,Department,Position,Salary,IsActive")]
        Employee employee
    ) {
        if (ModelState.IsValid)
        {
            try
            {
                _employeeRepository.UpdateEmployee(employee);
            }
            catch
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }
}
