using Kahramanlar.RepositoryLayer.SupportInterface;

namespace Kahramanlar.RepositoryLayer.Models.Odemeler
{
    public class OdemeRepository(FirebaseDbContext context) : GenericRepository<OdemeModel>(context, "Odemeler"), IOdemeRepository
    {
        public async Task<List<OdemeModel?>> GetOdemelerByDateRange(DateTime startDate, DateTime endDate)
        {
            var querySnapshot = await _collectionName
                .WhereGreaterThanOrEqualTo("Tarih", startDate)
                .WhereLessThanOrEqualTo("Tarih", endDate)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<OdemeModel?>())
                .ToList();
        }

        public async Task<List<OdemeModel?>> GetOdemelerByMusteriId(string musteriId)
        {
            var querySnapshot = await _collectionName
                .WhereEqualTo("MusteriId", musteriId)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<OdemeModel?>())
                .ToList();
        }

        public async Task<List<OdemeModel?>> GetOdemelerByTuru(string turu)
        {
            var querySnapshot = await _collectionName
                .WhereEqualTo("Turu", turu)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<OdemeModel?>())
                .ToList();
        }

        public async Task<List<OdemeModel?>> GetOdemelerByTutarRange(double minTutar, double maxTutar)
        {
            var querySnapshot = await _collectionName
                .WhereGreaterThanOrEqualTo("Tutar", minTutar)
                .WhereLessThanOrEqualTo("Tutar", maxTutar)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<OdemeModel?>())
                .ToList();
        }
    }
}