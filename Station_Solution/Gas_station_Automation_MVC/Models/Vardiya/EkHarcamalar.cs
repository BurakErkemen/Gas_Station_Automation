using Google.Cloud.Firestore;

namespace Gas_station_Automation_MVC.Models.Vardiya;

[FirestoreData]
public class EkHarcamalar
{
    [FirestoreDocumentId]
    public string EkHarcamalarId { get; set; } = default!;

    [FirestoreProperty]
    public string HarcamaTuru { get; set; } = default!;
    [FirestoreProperty]
    public decimal Tutar { get; set; }
    [FirestoreProperty]
    public string Aciklama { get; set; } = default!;
    [FirestoreProperty]
    public string VardiyaId { get; set; } = default!;
    [FirestoreProperty]
    public Timestamp CreatedAt { get; set; }
    [FirestoreProperty]
    public string CreatedByUid { get; set; } = default!;
    [FirestoreProperty]
    public bool IsActive { get; set; } = true;
}

