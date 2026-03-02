using Google.Cloud.Firestore;

namespace Kahramanlar.RepositoryLayer.Models.Faturalar
{
    [FirestoreData]
    public class FaturaModel
    {
        [FirestoreProperty]
        public string FaturaId { get; set; } = default!;

        [FirestoreProperty]
        public string Turu { get; set; } = default!;

        [FirestoreProperty]
        public int FisNo { get; set; }

        [FirestoreProperty]
        public double Lt { get; set; }

        [FirestoreProperty]
        public double Tutar { get; set; }

        [FirestoreProperty]
        public DateTime Tarih { get; set; }

        [FirestoreProperty]
        public DateTime CreatedAt { get; set; }
    }
}
