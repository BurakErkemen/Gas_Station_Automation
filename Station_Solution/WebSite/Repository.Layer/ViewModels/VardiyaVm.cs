using Google.Cloud.Firestore;

namespace WebSite.Repository.Layer.ViewModels;

public class VardiyaVm
{
    public List<string> CalisanId { get; set; } = new();
    public string VardiyaNo { get; set; } = default!;
    public Timestamp Tarih { get; set; }
    public Timestamp Baslangic { get; set; }
    public Timestamp Bitis { get; set; }
    public double ToplamPara { get; set; }
    public double ToplamLt { get; set; }
    public string? Not { get; set; }
    public List<string>? OtobilId { get; set; } = new();
    public List<string>? VeresiyeId { get; set; } = new();
    public List<string>? EkharcamaId { get; set; } = new();
}

