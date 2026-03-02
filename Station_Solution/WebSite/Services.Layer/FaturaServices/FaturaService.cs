using WebSite.Repository.Layer.ViewModels;

namespace WebSite.Services.Layer.FaturaServices
{
    public class FaturaService : IFaturaService
    {
        public Task<List<FaturaVm>> GetByCalisanIdAsync(string calisanId)
        {
            throw new NotImplementedException();
        }

        public Task<List<FaturaVm>> GetByFisNoAsync(string turu)
        {
            throw new NotImplementedException();
        }

        public Task<List<FaturaVm>> GetByTarihRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<FaturaVm>> GetByTuruAsync(string turu)
        {
            throw new NotImplementedException();
        }

        public Task<List<FaturaVm>> GetByVardiyaIdAsync(string vardiyaId)
        {
            throw new NotImplementedException();
        }
    }
}
