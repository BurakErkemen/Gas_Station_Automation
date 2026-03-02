using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class AlisFatura
{
    [FirestoreDocumentId]
    public string FaturaId { get; set; } = default!;

    [FirestoreProperty("turu")]
    public string Turu { get; set; } = default!;

    [FirestoreProperty("fisno")]
    public int FisNo { get; set; }

    [FirestoreProperty("lt")]
    public double Lt { get; set; }

    [FirestoreProperty("tutar")]
    public double Tutar { get; set; }

    [FirestoreProperty("tarih")]
    public Timestamp Tarih { get; set; }

    [FirestoreProperty("createdAt")]
    public Timestamp CreatedAt { get; set; }
}
