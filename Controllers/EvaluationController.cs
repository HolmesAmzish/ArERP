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
        private readonly AppDbContext _context;

        public EvaluationController(
            IEvaluationRepository evaluationRepository,
            AppDbContext context)
        {
            _evaluationRepository = evaluationRepository;
            _context = context;
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

        public IActionResult Details(int id)
        {
            var evaluation = _evaluationRepository.GetEvaluationById(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            return View(evaluation);
        }

        public IActionResult Create()
        {
            var evaluation = new EvaluationHeader
            {
                Details = new List<EvaluationDetail> { new EvaluationDetail() }
            };

            ViewBag.Employees = new SelectList(_context.Employees
                .Where(e => e.IsActive)
                .Select(e => new { e.Id, e.EmployeeName }), 
                "Id", "EmployeeName");

            return View(evaluation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EvaluationHeader header, List<EvaluationDetail> details)
        {
            // if (ModelState.IsValid)
            // {
                _evaluationRepository.AddHeader(evaluation);
                _evaluationRepository.AddDetails(details);
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

            ViewBag.Employees = new SelectList(_context.Employees
                .Where(e => e.IsActive)
                .Select(e => new { e.Id, e.EmployeeName }), 
                "Id", "EmployeeName");

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

            if (ModelState.IsValid)
            {
                _evaluationRepository.UpdateEvaluation(evaluation);
                return RedirectToAction(nameof(Index));
            }
            return View(evaluation);
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
