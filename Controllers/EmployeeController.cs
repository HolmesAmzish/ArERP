using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ArERP.Models.Entity;
using ArERP.Repository;

namespace ArERP.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employerRepository)
        {
            _employeeRepository = employerRepository;
        }

        // GET: api/employee
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeEntity>> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        // POST: api/employee
        [HttpPost]
        public ActionResult<EmployeeEntity> CreateEmployee([FromBody] EmployeeEntity employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _employeeRepository.AddEmployee(employee);
            return Ok();
        }
    }
}