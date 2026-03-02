using Google.Cloud.Firestore;

namespace Kahramanlar.RepositoryLayer.SupportInterface
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FirestoreDb _firestoreDb;
        protected readonly CollectionReference _collectionName;

        public GenericRepository(FirebaseDbContext context, string collectionName)
        {
            _firestoreDb = context.GetFirestoreDb();
            _collectionName = _firestoreDb.Collection(collectionName);
        }

        public async Task<string> AddAsync(T entity)
        {
            DocumentReference documentReference = await _collectionName.AddAsync(entity);

            // Modelin 'Id' alanına Firestore'un oluşturduğu belge kimliğini ata
            var entityType = typeof(T);
            var idProperty = entityType.GetProperty("Id");

            if (idProperty != null && idProperty.CanWrite)
            {
                idProperty.SetValue(entity, documentReference.Id); // Firestore'un ID'sini modele ekle
            }

            await documentReference.SetAsync(entity); // Güncellenmiş modeli Firestore'a kaydet
            return documentReference.Id;
        }

        public async Task UpdateAsync(string id, T entity)
        {
            DocumentReference documentReference = _collectionName.Document(id);
            await documentReference.SetAsync(entity, SetOptions.Overwrite); // Var olan belgeyi tamamen güncelle
        }

        public async Task DeleteAsync(string id) => await _collectionName.Document(id).DeleteAsync();

        public async Task<List<T>> GetAllAsync()
        {
            QuerySnapshot snapshots = await _collectionName.GetSnapshotAsync();
            return snapshots.Select(snapshot => snapshot.ConvertTo<T>()).ToList();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            DocumentSnapshot snapshots = await _collectionName.Document(id).GetSnapshotAsync();
            return snapshots.Exists ? snapshots.ConvertTo<T>() : null;
        }
    }
}
