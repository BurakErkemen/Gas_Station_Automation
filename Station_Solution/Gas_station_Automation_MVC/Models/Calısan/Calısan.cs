using Google.Cloud.Firestore;

namespace Gas_station_Automation_MVC.Models.Calısan;

[FirestoreData]
public class Calısan
{
    [FirestoreDocumentId]
    public string CalisanId { get; set; } = default!;
    [FirestoreProperty]
    public string AdSoyad { get; set; } = default!;
    [FirestoreProperty]
    public string TcNo { get; set; } = default!;
    [FirestoreProperty]
    public string TelefonNo { get; set; } = default!;
    [FirestoreProperty]
    public string? Email { get; set; } 
    [FirestoreProperty]
    public string? Adres { get; set; } = default!;
    [FirestoreProperty]
    public string Pozisyon { get; set; } = default!;
    [FirestoreProperty]
    public decimal Maas { get; set; }
    [FirestoreProperty]
    public Timestamp IseGirisTarihi { get; set; }
    [FirestoreProperty]
    public string CreatedByUid { get; set; } = default!;
    [FirestoreProperty]
    public Timestamp CreatedAt { get; set; }
    [FirestoreProperty]
    public bool IsActive { get; set; } = true;
}

