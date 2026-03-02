using WebSite.Repository.Layer.ViewModels;

namespace WebSite.Services.Layer.VardiyaServices
{
    public class VardiyaService : IVardiyaService
    {
        public Task<List<VardiyaVm>> GetByCalisanIdAsync(string calisanId)
        {
            throw new NotImplementedException();
        }

        public Task<List<VardiyaVm>> GetByTarihRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<VardiyaVm>> GetByToplamLtRangeAsync(double minLt, double maxLt)
        {
            throw new NotImplementedException();
        }

        public Task<List<VardiyaVm>> GetByToplamParaRangeAsync(double minPara, double maxPara)
        {
            throw new NotImplementedException();
        }

        public Task<List<VardiyaVm>> GetByVardiyaNoAsync(string vardiyaNo)
        {
            throw new NotImplementedException();
        }
    }
}
