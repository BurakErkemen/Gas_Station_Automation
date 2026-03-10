using Kahramanlar.RepositoryLayer.SupportInterface;

namespace Kahramanlar.RepositoryLayer.Models.Calisanlar
{
    public interface ICalisanRepository : IGenericRepository<CalisanModel>
    {
        Task<List<CalisanModel>> GetCalisanlarByIseGirisOrIstenCikisRangeAsync(DateTime startDate, DateTime endDate);
        Task<CalisanModel?> GetCalisanByTcNoAsync(string tcNo);
        Task<List<CalisanModel?>> GetCalısanlarByIsActiveAsync(bool isActive);
    }
}
