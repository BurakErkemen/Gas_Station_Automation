using WebSite.Repository.Layer.ViewModels;

namespace WebSite.Services.Layer.VardiyaServices
{
    public interface IVardiyaService 
    {
        Task<List<VardiyaVm>> GetByVardiyaNoAsync(string vardiyaNo);
        Task<List<VardiyaVm>> GetByCalisanIdAsync(string calisanId);
        Task<List<VardiyaVm>> GetByTarihRangeAsync(DateTime startDate, DateTime endDate);
        Task<List<VardiyaVm>> GetByToplamParaRangeAsync(double minPara, double maxPara);
        Task<List<VardiyaVm>> GetByToplamLtRangeAsync(double minLt, double maxLt);
    }
}
