using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class EkHarcama
{
    [FirestoreDocumentId]
    public string EkHarcamaId { get; set; } = default!;

    [FirestoreProperty("tutar")]
    public double Tutar { get; set; }

    [FirestoreProperty("aciklama")]
    public string Aciklama { get; set; } = default!;
}
