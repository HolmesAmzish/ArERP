using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Repository;

public interface IWorkshopRepository
{
    List<Workshop> GetAllWorkshops();
}