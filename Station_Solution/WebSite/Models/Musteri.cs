using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class Musteri
{
    [FirestoreDocumentId]
    public string MusteriId { get; set; } = default!;

    [FirestoreProperty("adi")]
    public string Adi { get; set; } = default!;

    [FirestoreProperty("toplamBorc")]
    public double ToplamBorc { get; set; }

    [FirestoreProperty("phone")]
    public string Phone { get; set; } = default!;

    [FirestoreProperty("isActive")]
    public bool IsActive { get; set; } = true;
}
