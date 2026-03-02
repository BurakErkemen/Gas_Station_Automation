using Kahramanlar.RepositoryLayer.SupportInterface;

namespace Kahramanlar.RepositoryLayer.Models.Faturalar
{
    public interface IFaturaRepository : IGenericRepository<FaturaModel>
    {
        Task<List<FaturaModel?>> GetFaturalarByDateRange(DateTime startDate, DateTime endDate);
        Task<FaturaModel?> GetFaturaByFisNo(int fisNo);
        Task<List<FaturaModel?>> GetFaturalarByTuru(string turu);
        Task<List<FaturaModel?>> GetFaturalarByTutarRange(double minTutar, double maxTutar);
        Task<List<FaturaModel?>> GetFaturalarByLtRange(double minLt, double maxLt);
    }
}
