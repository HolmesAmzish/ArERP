using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Repository;

public interface IProcessOperationRepository
{
    List<ProcessOperation> GetAllProcessOperations();
    ProcessOperation? GetProcessOperationsById(int id);
    void AddProcessOperation(ProcessOperation processOperation);
    void RemoveProcessOperation(ProcessOperation processOperation);
}