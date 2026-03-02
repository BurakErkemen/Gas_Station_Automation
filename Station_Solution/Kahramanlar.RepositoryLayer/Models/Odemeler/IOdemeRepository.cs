using Kahramanlar.RepositoryLayer.SupportInterface;

namespace Kahramanlar.RepositoryLayer.Models.Odemeler
{
    public interface IOdemeRepository : IGenericRepository<OdemeModel>
    {
        Task<List<OdemeModel?>> GetOdemelerByDateRange(DateTime startDate, DateTime endDate);
        Task<List<OdemeModel?>> GetOdemelerByTuru(string turu);
        Task<List<OdemeModel?>> GetOdemelerByTutarRange(double minTutar, double maxTutar);
         Task<List<OdemeModel?>> GetOdemelerByMusteriId(string musteriId);
    }
}