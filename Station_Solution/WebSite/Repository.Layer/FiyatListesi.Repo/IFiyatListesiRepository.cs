using WebSite.Models;

namespace WebSite.Repository.Layer.FiyatListesi.Repo
{
    public interface GetAllFiyatListesiAsync<T> where T : class
    {
        public Task<List<FiyatListesiModel>> GetAllFiyatListesi();
    }
}
