using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class Calisan
{
    [FirestoreDocumentId]
    public string CalisanId { get; set; } = default!;

    [FirestoreProperty("adi")]
    public string Adi { get; set; } = default!;

    [FirestoreProperty("tcNo")]
    public string TcNo { get; set; } = default!;

    [FirestoreProperty("telNo")]
    public string TelNo { get; set; } = default!;

    [FirestoreProperty("iseGirisTarihi")]
    public Timestamp IseGirisTarihi { get; set; }

    [FirestoreProperty("createdAt")]
    public Timestamp CreatedAt { get; set; }

    [FirestoreProperty("isActive")]
    public bool IsActive { get; set; } = true;
}