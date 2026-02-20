
using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class FiyatListesi
{
    [FirestoreDocumentId]
    public string ID { get; set; }

    [FirestoreProperty]
    public decimal LPG { get; set; }

    [FirestoreProperty]
    public decimal Diesel { get; set; }

    [FirestoreProperty]
    public decimal EuroDiesel { get; set; }

    [FirestoreProperty]
    public decimal Benzin { get; set; } 

    public Timestamp LastUpdate { get; set; }
}