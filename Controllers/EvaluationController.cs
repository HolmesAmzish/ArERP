using ArERP.Models.Entity;
using ArERP.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ArERP.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EvaluationController(
            IEvaluationRepository evaluationRepository,
            IEmployeeRepository employeeRepository)
        {
            _evaluationRepository = evaluationRepository;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index(string employeeId, string name, string department)
        {
            List<EvaluationHeader> evaluations;
            if (string.IsNullOrEmpty(employeeId) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(department))
            {
                evaluations = _evaluationRepository.GetAllEvaluations();
            }
            else
            {
                evaluations = _evaluationRepository.SearchEvaluations(employeeId, name, department);
            }
            return View(evaluations);
        }

        // Get Evalution/Details/{id}
        public IActionResult Details(int id)
        {
            var evaluation = _evaluationRepository.GetEvaluationById(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            return View(evaluation);
        }

        // GET Evalution/Create
        public IActionResult Create()
        {
            var evaluation = new EvaluationHeader
            {
                EvaluationDate = DateTime.Today,
                Details = new List<EvaluationDetail> { new EvaluationDetail() }
            };
            
            var employees = _employeeRepository
                .GetAllEmployees()
                .Where(e => e.IsActive == true)
                .ToList();

            // Convert to SelectList
            ViewBag.Employees = new SelectList(employees, "Id", "EmployeeName");

            return View(evaluation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EvaluationHeader evaluation)
        {
            // if (ModelState.IsValid)
            // {
                _evaluationRepository.AddEvaluation(evaluation);
                return RedirectToAction(nameof(Index));
            // }
            // return View(evaluation);
        }

        public IActionResult Edit(int id)
        {
            var evaluation = _evaluationRepository.GetEvaluationById(id);
            if (evaluation == null)
            {
                return NotFound();
            }

            var employees = _employeeRepository
                .GetAllEmployees()
                .Where(e => e.IsActive==true)
                .ToList();

            ViewBag.Employees = new SelectList(employees, "Id", "EmployeeName");

            return View(evaluation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EvaluationHeader evaluation)
        {
            if (id != evaluation.Id)
            {
                return NotFound();
            }

            // if (ModelState.IsValid)
            // {
                _evaluationRepository.UpdateEvaluation(evaluation);
                return RedirectToAction(nameof(Index));
            // }
            // return View(evaluation);
        }

        public IActionResult Delete(int id)
        {
            var evaluation = _evaluationRepository.GetEvaluationById(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            return View(evaluation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _evaluationRepository.DeleteEvaluation(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
