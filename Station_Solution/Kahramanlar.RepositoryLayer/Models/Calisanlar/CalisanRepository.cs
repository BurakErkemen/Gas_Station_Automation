using Kahramanlar.RepositoryLayer.SupportInterface;

namespace Kahramanlar.RepositoryLayer.Models.Calisanlar
{
    public class CalisanRepository(FirebaseDbContext context) : GenericRepository<CalisanModel>(context, "Calisanlar"), ICalisanRepository
    {
        public async Task<CalisanModel?> GetCalisanByTcNoAsync(string tcNo)
        {
            var snap = await _collectionName.WhereEqualTo("TcNo", tcNo).Limit(1).GetSnapshotAsync();
            var doc = snap.Documents.FirstOrDefault();
            return doc is null ? null : doc.ConvertTo<CalisanModel>();
        }

        public async Task<List<CalisanModel>> GetCalisanlarByIseGirisOrIstenCikisRangeAsync(DateTime startDate, DateTime endDate)
        {
            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

            // 1) İşe giriş aralığında olanlar
            var iseGirisTask = _collectionName
                .WhereGreaterThanOrEqualTo("IseGirisTarihi", startDate)
                .WhereLessThanOrEqualTo("IseGirisTarihi", endDate)
                .OrderBy("IseGirisTarihi")
                .GetSnapshotAsync();

            // 2) İşten çıkış aralığında olanlar
            var istenCikisTask = _collectionName
                .WhereGreaterThanOrEqualTo("IstenCikisTarihi", startDate)
                .WhereLessThanOrEqualTo("IstenCikisTarihi", endDate)
                .OrderBy("IstenCikisTarihi")
                .GetSnapshotAsync();

            await Task.WhenAll(iseGirisTask, istenCikisTask);

            var iseGirisSnap = iseGirisTask.Result;
            var istenCikisSnap = istenCikisTask.Result;

            // 3) Id’ye göre birleştir (duplicate’leri ele)
            var dict = new Dictionary<string, CalisanModel>();

            foreach (var doc in iseGirisSnap.Documents)
            {
                var m = doc.ConvertTo<CalisanModel>();
                // Eğer modelde Id yoksa: m.Id = doc.Id;
                dict[doc.Id] = m;
            }

            foreach (var doc in istenCikisSnap.Documents)
            {
                var m = doc.ConvertTo<CalisanModel>();
                dict[doc.Id] = m;
            }

            // İstersen sıralama: aralık içinde ilk görülen tarihe göre
            // Burada basitçe işe giriş tarihine göre sıralıyorum; ihtiyacına göre değiştir
            return dict.Values
                .OrderBy(x => x.IseGirisTarihi) // property adı sende neyse
                .ToList();
        }

        public async Task<List<CalisanModel?>> GetCalısanlarByIsActiveAsync(bool isActive)
        {
            var querySnapshot = await _collectionName
                .WhereEqualTo("IsActive", isActive)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<CalisanModel?>())
                .ToList();
        }
    }
}