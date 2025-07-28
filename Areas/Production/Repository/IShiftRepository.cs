using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Repository;

public interface IShiftRepository
{
    List<Shift> GetAllShifts();
}