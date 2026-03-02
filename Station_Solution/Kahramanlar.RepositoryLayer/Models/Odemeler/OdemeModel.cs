using Google.Cloud.Firestore;
using System.ComponentModel;

namespace Kahramanlar.RepositoryLayer.Models.Odemeler
{
    [FirestoreData]
    public class OdemeModel
    {
        [FirestoreProperty]
        public string OdemeId { get; set; } = default!;

        [FirestoreProperty]
        public string MusteriId { get; set; } = default!;

        [FirestoreProperty]
        public string Turu { get; set; } =default!;

        [FirestoreProperty]
        public double Tutar { get; set;}

        [FirestoreProperty]
        public DateTime Tarih { get; set; }

        [FirestoreProperty]
        public DateTime CreatedAt { get; set; }
    }
}