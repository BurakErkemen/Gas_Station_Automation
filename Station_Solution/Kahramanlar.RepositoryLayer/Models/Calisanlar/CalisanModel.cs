using Google.Cloud.Firestore;

namespace Kahramanlar.RepositoryLayer.Models.Calisanlar
{
    [FirestoreData]
    public class CalisanModel
    {
        [FirestoreProperty]
        public string CalisanId { get; set; } = default!;

        [FirestoreProperty]
        public string Ad { get; set; } = default!;

        [FirestoreProperty]
        public string TelNo { get; set; } = default!;

        [FirestoreProperty]
        public string TcNo { get; set; } = default!;

        [FirestoreProperty]
        public bool IsActive { get; set; }

        [FirestoreProperty]
        public DateTime IseGirisTarihi { get; set; }

        [FirestoreProperty]
        public DateTime CreatedAt { get; set; }

    }
}
