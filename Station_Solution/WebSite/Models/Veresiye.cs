using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class Veresiye
{
    [FirestoreDocumentId]
    public string VeresiyeId { get; set; } = default!;

    [FirestoreProperty("vardiyaId")]
    public string VardiyaId { get; set; } = default!;

    [FirestoreProperty("musteriId")]
    public string MusteriId { get; set; } = default!;

    [FirestoreProperty("fisNo")]
    public int FisNo { get; set; }

    [FirestoreProperty("lt")]
    public double Lt { get; set; }

    [FirestoreProperty("tutar")]
    public double Tutar { get; set; }
}
