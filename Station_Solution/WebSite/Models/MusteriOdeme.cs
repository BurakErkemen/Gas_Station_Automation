using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class MusteriOdeme
{
    [FirestoreDocumentId]
    public string OdemeId { get; set; } = default!;

    [FirestoreProperty("musteriId")]
    public string MusteriId { get; set; } = default!;

    [FirestoreProperty("turu")]
    public string Turu { get; set; } = default!;

    [FirestoreProperty("tutar")]
    public double Tutar { get; set; }

    [FirestoreProperty("tarih")]
    public Timestamp Tarih { get; set; }

    [FirestoreProperty("createdAt")]
    public Timestamp CreatedAt { get; set; }
}
