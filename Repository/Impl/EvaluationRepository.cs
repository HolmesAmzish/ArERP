using ArERP.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ArERP.Repository.Impl
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly AppDbContext _context;

        public EvaluationRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<EvaluationHeader> GetAllEvaluations()
        {
            return _context.EvaluationHeader
                // .Include(e => e.Details)
                // .ThenInclude(d => d.Employee)
                .ToList();
        }

        public EvaluationHeader GetEvaluationById(int id)
        {
            return _context.EvaluationHeader
                .Include(e => e.Details)
                .ThenInclude(d => d.Employee)
                .FirstOrDefault(e => e.Id == id);
        }

        public List<EvaluationHeader> SearchEvaluations(string employeeId, string name, string department)
        {
            var query = _context.EvaluationHeader
                .Include(e => e.Details)
                .ThenInclude(d => d.Employee)
                .AsQueryable();

            if (!string.IsNullOrEmpty(employeeId))
            {
                query = query.Where(e => e.Details.Any(d => 
                    d.Employee.Id.ToString().Contains(employeeId)));
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Details.Any(d => 
                    d.Employee.EmployeeName.Contains(name)));
            }

            if (!string.IsNullOrEmpty(department))
            {
                query = query.Where(e => e.Details.Any(d => 
                    d.Employee.DepartmentId.ToString().Contains(department)));
            }

            return query.ToList();
        }

        public void AddEvaluation(EvaluationHeader header, List<EvaluationDetail> details)
        {
            _context.EvaluationHeader.Add(header);
            _context.EvaluationDetail.AddRange(details);
            _context.SaveChanges();
        }

        public void UpdateEvaluation(EvaluationHeader evaluation)
        {
            _context.EvaluationHeader.Update(evaluation);
            _context.SaveChanges();
        }

        public void DeleteEvaluation(int id)
        {
            var evaluation = GetEvaluationById(id);
            if (evaluation != null)
            {
                _context.EvaluationHeader.Remove(evaluation);
                _context.SaveChanges();
            }
        }
    }
}
