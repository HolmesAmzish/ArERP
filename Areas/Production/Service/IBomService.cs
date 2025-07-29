using ArERP.Areas.Production.Models;

namespace ArERP.Areas.Production.Service
{
    public interface IBomService
    {
        IEnumerable<Bom> GetAllBoms();
        Bom GetBomById(int id);
        void CreateBom(Bom bom);
        void UpdateBom(Bom bom);
        void DeleteBom(int id);
        IEnumerable<BomLines> GetBomLines(int bomId);
    }
}
