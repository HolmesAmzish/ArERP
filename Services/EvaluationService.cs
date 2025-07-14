using ArERP.Models.Entity;
using ArERP.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ArERP.Services
{
    public class EvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly AppDbContext _context;

        public EvaluationService(IEvaluationRepository evaluationRepository, 
                               AppDbContext context)
        {
            _evaluationRepository = evaluationRepository;
            _context = context;
        }

        public EvaluationHeader CreateEvaluation(EvaluationHeader header)
        {
            // Calculate final scores
            header.Details = CalculateFinalScores(header.Details);
            return _evaluationRepository.AddEvaluation(header);
        }

        public EvaluationHeader GetEvaluation(int id)
        {
            return _evaluationRepository.GetEvaluationById(id);
        }

        public List<EvaluationHeader> SearchEvaluations(string employeeId, string name, string department)
        {
            return _evaluationRepository.SearchEvaluations(employeeId, name, department);
        }

        public void UpdateEvaluation(EvaluationHeader header) 
        {
            header.Details = CalculateFinalScores(header.Details);
            _evaluationRepository.UpdateEvaluation(header);
        }

        public void DeleteEvaluation(int id)
        {
            _evaluationRepository.DeleteEvaluation(id);
        }

        public List<EvaluationDetail> CalculateFinalScores(List<EvaluationDetail> details)
        {
            // Apply business rules for score calculation
            foreach(var detail in details)
            {
                // Example: Ensure total score doesn't exceed 200
                if(detail.TotalScore > 200)
                {
                    detail.PerformanceScore = 100;
                    detail.QualityScore = 100;
                }
            }
            return details;
        }
    }
}
