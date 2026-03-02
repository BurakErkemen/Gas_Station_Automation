using Kahramanlar.RepositoryLayer.SupportInterface;

namespace Kahramanlar.RepositoryLayer.Models.Kullanıcılar
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        Task<List<UserModel?>> GetUserByName(string Name);
        Task<UserModel?> GetUserByEmail(string Email);

        // Toplam borcu belirli bir limitin üzerinde olanları listeleme (Opsiyonel)
        Task<List<UserModel?>> GetUsersByDebtStatusAsync(double minDebt);
    }
}