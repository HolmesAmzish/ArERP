using ArERP.Areas.Production.Models;
using ArERP.Data;

namespace ArERP.Areas.Production.Repository.Impl;

public class ProcessOperationRepository : IProcessOperationRepository
{
    private readonly AppDbContext _context;

    public ProcessOperationRepository(AppDbContext context)
    {
        this._context = context;
    }
    
    public List<ProcessOperation> GetAllProcessOperations() =>
        _context.ProcessOperations
            .ToList();
    

    public ProcessOperation? GetProcessOperationsById(int id) =>
        _context.ProcessOperations
            .FirstOrDefault(po => po.Id == id);
    

    public void AddProcessOperation(ProcessOperation processOperation)
    {
        _context.ProcessOperations
            .Add(processOperation);
    }

    public void RemoveProcessOperation(ProcessOperation processOperation)
    {
        _context.ProcessOperations
            .Remove(processOperation);
    }
}