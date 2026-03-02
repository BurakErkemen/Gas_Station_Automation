using Kahramanlar.RepositoryLayer.SupportInterface;

namespace Kahramanlar.RepositoryLayer.Models.Calisanlar
{
    public class CalisanRepository(FirebaseDbContext context) : GenericRepository<CalisanModel>(context, "Calisanlar"), ICalisanRepository
    {

    }
}