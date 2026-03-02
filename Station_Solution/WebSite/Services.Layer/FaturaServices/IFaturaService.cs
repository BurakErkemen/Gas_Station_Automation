using WebSite.Repository.Layer.ViewModels;

namespace WebSite.Services.Layer.FaturaServices
{
    public interface IFaturaService 
    {
        Task<List<FaturaVm>> GetByVardiyaIdAsync(string vardiyaId);
        Task<List<FaturaVm>> GetByCalisanIdAsync(string calisanId);
        Task<List<FaturaVm>> GetByTarihRangeAsync(DateTime startDate, DateTime endDate);
        Task<List<FaturaVm>> GetByTuruAsync(string turu);
        Task<List<FaturaVm>> GetByFisNoAsync(string turu);
    }
}
