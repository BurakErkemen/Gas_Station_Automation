using Google.Cloud.Firestore;

namespace WebSite.Models;

[FirestoreData]
public class Vardiya
{
    [FirestoreDocumentId]
    public string VardiyaId { get; set; } = default!;

    [FirestoreProperty("calisanId")]
    public List<string> CalisanId { get; set; } = new();

    [FirestoreProperty("vardiyaNo")]
    public string VardiyaNo { get; set; } = default!;

    [FirestoreProperty("tarih")]
    public Timestamp Tarih { get; set; }

    [FirestoreProperty("baslangic")]
    public Timestamp Baslangic { get; set; }

    [FirestoreProperty("bitis")]
    public Timestamp Bitis { get; set; }

    // Diyagramda string görünüyor; pratikte sayısal tutmak daha sağlıklı
    [FirestoreProperty("toplamPara")]
    public double ToplamPara { get; set; }

    [FirestoreProperty("toplamLt")]
    public double ToplamLt { get; set; }

    [FirestoreProperty("not")]
    public string? Not { get; set; }

    [FirestoreProperty("createdAt")]
    public Timestamp CreatedAt { get; set; }

    // Diyagrama göre vardiya içinde ID listeleri var:
    [FirestoreProperty("otobilId")]
    public List<string> OtobilId { get; set; } = new();

    [FirestoreProperty("veresiyeId")]
    public List<string> VeresiyeId { get; set; } = new();

    [FirestoreProperty("ekHarcamaId")]
    public List<string> EkHarcamaId { get; set; } = new();
}
