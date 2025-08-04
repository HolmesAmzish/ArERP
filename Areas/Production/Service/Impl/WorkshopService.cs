using ArERP.Areas.Production.Models;
using ArERP.Areas.Production.Repository;
using ArERP.Data;

namespace ArERP.Areas.Production.Service.Impl;

public class WorkshopService : IWorkshopService
{
    private readonly IWorkshopRepository _workshopRepository;

    public WorkshopService(IWorkshopRepository workshopRepository)
    {
        this._workshopRepository = workshopRepository;
    }

    public List<Workshop> GetAllWorkshops() => _workshopRepository.GetAllWorkshops();
}