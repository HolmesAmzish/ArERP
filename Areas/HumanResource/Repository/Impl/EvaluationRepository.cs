using Microsoft.EntityFrameworkCore;
using ArERP.Areas.HumanResource.Models;
using ArERP.Repository;

namespace ArERP.Areas.HumanResource.Repositories.Impl;

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
        var evalution = _context.EvaluationHeader
            .Include(e => e.Details)
            .ThenInclude(d => d.Employee)
            .FirstOrDefault(e => e.Id == id);
        if (evalution == null)
        {
            throw new Exception("Evaluation record not found.");
        }
        return evalution;
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

    public void AddEvaluation(EvaluationHeader header)
    {
        _context.EvaluationHeader.Add(header);
        _context.SaveChanges();
    }

    // Update Evaluation
    public void UpdateEvaluation(EvaluationHeader updatedEvaluation)
    {
        var existing = _context.EvaluationHeader
            .Include(h => h.Details)
            .FirstOrDefault(h => h.Id == updatedEvaluation.Id);

        if (existing == null)
        {
            throw new Exception("Evaluation record not found.");
        }

        _context.Entry(existing).CurrentValues.SetValues(updatedEvaluation);

        foreach (var detail in updatedEvaluation.Details)
        {
            var existingDetail = existing.Details.FirstOrDefault(d => d.Id == detail.Id);

            if (existingDetail != null)
            {
                _context.Entry(existingDetail).CurrentValues.SetValues(detail);
            }
            else
            {
                detail.Id = 0;
                existing.Details.Add(detail);
            }
        }

        // var removedDetails = existing.Details
        //     .Where(d => !updatedEvaluation.Details.Any(ed => ed.Id == d.Id))
        //     .ToList();
        //
        // foreach (var removed in removedDetails)
        // {
        //     _context.EvaluationDetail.Remove(removed);
        // }

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

