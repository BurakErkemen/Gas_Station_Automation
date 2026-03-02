
using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class FiyatListesiModel
{
    [FirestoreDocumentId]
    public string ID { get; set; }

    [FirestoreProperty]
    public double LPG { get; set; }

    [FirestoreProperty]
    public double Diesel { get; set; }

    [FirestoreProperty]
    public double EuroDiesel { get; set; }

    [FirestoreProperty]
    public double Benzin { get; set; } 

    public Timestamp LastUpdate { get; set; }
}