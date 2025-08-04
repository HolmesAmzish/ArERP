using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Service;

public interface IWorkshopService
{
    List<Workshop> GetAllWorkshops();
}