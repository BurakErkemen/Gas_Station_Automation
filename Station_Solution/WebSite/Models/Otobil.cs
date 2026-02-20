using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class Otobil
{
    [FirestoreDocumentId]
    public string OtobilId { get; set; } = default!;

    [FirestoreProperty("vardiyaId")]
    public string VardiyaId { get; set; } = default!;

    [FirestoreProperty("plaka")]
    public string Plaka { get; set; } = default!;

    [FirestoreProperty("lt")]
    public double Lt { get; set; }

    [FirestoreProperty("tutar")]
    public double Tutar { get; set; }

    [FirestoreProperty("fisNo")]
    public int FisNo { get; set; }

    [FirestoreProperty("tarih")]
    public Timestamp Tarih { get; set; }

    [FirestoreProperty("createdAt")]
    public Timestamp CreatedAt { get; set; }
}