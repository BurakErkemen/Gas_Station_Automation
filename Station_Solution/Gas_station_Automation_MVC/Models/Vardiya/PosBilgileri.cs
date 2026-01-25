using Google.Cloud.Firestore;

namespace Gas_station_Automation_MVC.Models.Vardiya;

[FirestoreData]
public class PosBilgileri
{
    [FirestoreDocumentId]
    public string PosId{ get; set; } = default!;

    [FirestoreProperty]
    public string KartAdı { get; set; } = default!;

    [FirestoreProperty]
    public decimal SatısTutarı { get; set; }

    [FirestoreProperty]
    public string VardiyaID{ get; set; } = default!;
}

