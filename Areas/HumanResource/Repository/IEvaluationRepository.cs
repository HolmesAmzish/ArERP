using ArERP.Areas.HumanResource.Models;

namespace ArERP.Areas.HumanResource.Repository;

public interface IEvaluationRepository
{
    List<EvaluationHeader> GetAllEvaluations();
    EvaluationHeader GetEvaluationById(int id);
    List<EvaluationHeader> SearchEvaluations(string employeeId, string name, string department);
    void AddEvaluation(EvaluationHeader evaluation);
    void UpdateEvaluation(EvaluationHeader evaluation);
    void DeleteEvaluation(int id);
}

