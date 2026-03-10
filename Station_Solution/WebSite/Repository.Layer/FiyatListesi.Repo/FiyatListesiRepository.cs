using Google.Cloud.Firestore;
using WebSite.Models;

namespace WebSite.Repository.Layer.FiyatListesi.Repo
{
    public class FiyatListesiRepository<T> : IFiyatListesiRepository<T> 
        where T : FiyatListesiModel
    {
        protected readonly FirestoreDb _firestoredb;
        protected readonly string _collectionName;
        public FiyatListesiRepository(FirestoreDb firestoredb, string collectionName)
        {
            _firestoredb = firestoredb;
            this.collectionName = collectionName;
        }

        public async Task<List<FiyatListesiModel>> GetAllFiyatListesiAsync()
        {
            QuerySnapshot snapshots = await _collectionName.Get;
            return snapshots.Select(snapshot => snapshot.ConvertTo<FiyatListesiModel>()).ToList();
        }
    }
}
