using Google.Cloud.Firestore;

namespace WebSite.Repository.Layer.ViewModels;

public class FaturaVm
{
    public string? Turu { get; set; }
    public int FisNo { get; set; }
    public double Lt { get; set; }
    public double Tutar { get; set; }
    public Timestamp Tarih { get; set; }
    public  Timestamp CreatedAt { get; set; }
}
