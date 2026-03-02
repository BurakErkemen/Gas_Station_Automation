using Kahramanlar.RepositoryLayer.SupportInterface;

namespace Kahramanlar.RepositoryLayer.Models.Kullanıcılar
{
    public class UserRepository(FirebaseDbContext context) : GenericRepository<UserModel>(context, "Kullanıcılar"), IUserRepository
    {
        public async Task<UserModel?> GetUserByEmail(string Email)
        {
            var querySnapshot = await _collectionName
                .WhereEqualTo("UserEmail", Email)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<UserModel?>())
                .FirstOrDefault();
        }

        public async Task<List<UserModel?>> GetUserByName(string Name)
        {
            var querySnapshot = await _collectionName
                .WhereEqualTo("UserName", Name)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<UserModel?>())
                .ToList();
        }

        public async Task<List<UserModel?>> GetUsersByDebtStatusAsync(double minDebt)
        {
            var querySnapshot = await _collectionName
                .WhereGreaterThanOrEqualTo("ToplamBorc", minDebt)
                .GetSnapshotAsync();

            return querySnapshot.Documents
                .Select(doc => doc.ConvertTo<UserModel?>())
                .ToList();
        }
    }
}