using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Repository;

public interface IBomRepository
{
    List<Bom> GetAllBom();
    Bom? GetBomById(int id);
    void AddBom(Bom bom);
    void RemoveBom(Bom bom);
    void UpdateBom(Bom bom);
}