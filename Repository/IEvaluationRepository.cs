using ArERP.Models.Entity;
using System.Collections.Generic;

namespace ArERP.Repository
{
    public interface IEvaluationRepository
    {
        List<EvaluationHeader> GetAllEvaluations();
        EvaluationHeader GetEvaluationById(int id);
        List<EvaluationHeader> SearchEvaluations(string employeeId, string name, string department);
        void AddEvaluation(EvaluationHeader evaluation, List<EvaluationDetail> details);
        void UpdateEvaluation(EvaluationHeader evaluation);
        void DeleteEvaluation(int id);
    }
}
