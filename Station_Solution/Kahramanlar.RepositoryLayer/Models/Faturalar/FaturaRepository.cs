using Kahramanlar.RepositoryLayer.SupportInterface;

namespace Kahramanlar.RepositoryLayer.Models.Faturalar
{
    public class FaturaRepository(FirebaseDbContext context) : GenericRepository<FaturaModel>(context, "FaturaListesi"), IFaturaRepository
    {
        public async Task<FaturaModel?> GetFaturaByFisNo(int fisNo)
        {
            var querySnapshot = await _collectionName
                .WhereEqualTo("FisNo", fisNo)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<FaturaModel>())
                .FirstOrDefault();
        }

        public async Task<List<FaturaModel?>> GetFaturalarByDateRange(DateTime startDate, DateTime endDate)
        {
            var querySnapshot = await _collectionName
                .WhereGreaterThanOrEqualTo("Tarih", startDate)
                .WhereLessThanOrEqualTo("Tarih", endDate)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<FaturaModel?>())
                .ToList();
        }

        public async Task<List<FaturaModel?>> GetFaturalarByLtRange(double minLt, double maxLt)
        {
            var querySnapshot = await _collectionName
                .WhereGreaterThanOrEqualTo("Lt", minLt)
                .WhereLessThanOrEqualTo("Lt", maxLt)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<FaturaModel?>())
                .ToList();
        }

        public async Task<List<FaturaModel?>> GetFaturalarByTuru(string turu)
        {
            var querySnapshot = await _collectionName
                .WhereEqualTo("Turu", turu)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<FaturaModel?>())
                .ToList();
        }

        public async Task<List<FaturaModel?>> GetFaturalarByTutarRange(double minTutar, double maxTutar)
        {
            var querySnapshot = await _collectionName
                .WhereGreaterThanOrEqualTo("Tutar", minTutar)
                .WhereLessThanOrEqualTo("Tutar", maxTutar)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<FaturaModel?>())
                .ToList();
        }
    }
}