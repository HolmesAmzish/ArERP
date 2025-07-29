using ArERP.Areas.Production.Models;
using ArERP.Areas.Production.Repository;

namespace ArERP.Areas.Production.Service.Impl
{
    public class BomService : IBomService
    {
        private readonly IBomRepository _bomRepository;

        public BomService(IBomRepository bomRepository)
        {
            _bomRepository = bomRepository;
        }

        public IEnumerable<Bom> GetAllBoms()
        {
            return _bomRepository.GetAllBom();
        }

        public Bom GetBomById(int id)
        {
            return _bomRepository.GetBomById(id);
        }

        public void CreateBom(Bom bom)
        {
            _bomRepository.AddBom(bom);
        }

        public void UpdateBom(Bom bom)
        {
            _bomRepository.UpdateBom(bom);
        }

        public void DeleteBom(int id)
        {
            var bom = _bomRepository.GetBomById(id);
            if (bom != null)
            {
                _bomRepository.RemoveBom(bom);
            }
        }

        public IEnumerable<BomLines> GetBomLines(int bomId)
        {
            // 假设repository有GetBomLines方法
            return new List<BomLines>(); // 临时实现
        }
    }
}
