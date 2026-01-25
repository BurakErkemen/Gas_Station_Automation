using Google.Cloud.Firestore;

namespace Gas_station_Automation_MVC.Models.Vardiya;

[FirestoreData]
public class Veresiye
{
    [FirestoreDocumentId]
    public string VeresiyeId { get; set; }

    [FirestoreProperty]
    public string UserId { get; set; } = default!;

    [FirestoreProperty]
    public string VardiyaID{ get; set; } = default!;


    [FirestoreProperty]
    public int FisNo { get; set; }

    [FirestoreProperty]
    public string YakıtTuru { get; set; } = default!;

    [FirestoreProperty]
    public decimal YakıtLT{ get; set; } = default!;

    [FirestoreProperty]
    public decimal Tutar { get; set; }

    [FirestoreProperty]
    public string Aciklama { get; set; } = default!;
}