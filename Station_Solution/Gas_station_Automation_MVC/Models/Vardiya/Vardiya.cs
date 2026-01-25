using Google.Cloud.Firestore;

namespace Gas_station_Automation_MVC.Models.Vardiya;

[FirestoreData]
public class Vardiya
{
    [FirestoreDocumentId]
    public string VardiyaId { get; set; } = default!;
    #region YakitBilgileri
    [FirestoreProperty]
    public decimal LPG_Lt { get; set; }

    [FirestoreProperty]
    public decimal LPG_Tutar { get; set; }

    [FirestoreProperty]
    public decimal Motorin_Lt { get; set; }

    [FirestoreProperty]
    public decimal Motorin_Tutar { get; set; }

    [FirestoreProperty]
    public decimal EuroDizel_Lt { get; set; }

    [FirestoreProperty]
    public decimal EuroDizel_Tutar { get; set; }

    [FirestoreProperty]
    public decimal Benzin_Lt { get; set; }

    [FirestoreProperty]
    public decimal Benzin_Tutar { get; set; }
    #endregion
    
    #region SaatBilgileri
    [FirestoreProperty]
    public Timestamp VardiyaBaslangic { get; set; }
    [FirestoreProperty]
    public Timestamp VardiyaBitis { get; set; }

    [FirestoreProperty]
    public Timestamp CreatedAt { get; set; }
    #endregion

    #region EkBilgiler
    [FirestoreProperty]
    public List<string> CalisanId { get; set; } = default!;

    [FirestoreProperty]
    public List<string>? VeresiyeId { get; set; }

    [FirestoreProperty]
    public List<string>? PosId { get; set; }

    [FirestoreProperty]
    public List<string>? EkHarcamalarId { get; set; }

    [FirestoreProperty]
    public decimal NakitSatıs{ get; set; }
    #endregion

    [FirestoreProperty]
    public string CreatedByUid { get; set; } = default!;

    [FirestoreProperty]
    public bool IsActive { get; set; } = true;

    [FirestoreProperty]
    public string? KapanisNotu { get; set; }


}


