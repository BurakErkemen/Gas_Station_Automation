using System.ComponentModel.DataAnnotations;

namespace WebSite.Models.ViewModels;

public class VardiyaFormVm
{
    // Wizard/sekme akışında ilk adımda oluşunca burada taşırız
    public string? VardiyaId { get; set; }

    [Required]
    public string VardiyaNo { get; set; } = default!;

    // Çalışan seçimi (checkbox/multiselect)
    public List<string> CalisanId { get; set; } = new();

    // Tarih/saat alanları UI’da DateTime alıp servis katmanında Timestamp’e çevirmek daha rahat
    [Required]
    public DateTime Tarih { get; set; }

    [Required]
    public DateTime Baslangic { get; set; }

    [Required]
    public DateTime Bitis { get; set; }

    public string? Not { get; set; }

    // Sekmeler
    public List<OtobilRowVm> Otobiller { get; set; } = new();
    public List<VeresiyeRowVm> Veresiyeler { get; set; } = new();
    public List<EkHarcamaRowVm> EkHarcamalar { get; set; } = new();

    // İsteğe bağlı: ödemeler & alış faturaları da aynı ekrandaysa
    public List<MusteriOdemeRowVm> MusteriOdemeleri { get; set; } = new();
    public List<AlisFaturaRowVm> AlisFaturalari { get; set; } = new();
}

public class OtobilRowVm
{
    [Required]
    public string Plaka { get; set; } = default!;

    [Range(0, 100000)]
    public double Lt { get; set; }

    [Range(0, 100000000)]
    public double Tutar { get; set; }

    public int FisNo { get; set; }
    public DateTime Tarih { get; set; }
}

public class VeresiyeRowVm
{
    [Required]
    public string MusteriId { get; set; } = default!;

    public int FisNo { get; set; }

    [Range(0, 100000)]
    public double Lt { get; set; }

    [Range(0, 100000000)]
    public double Tutar { get; set; }
}

public class EkHarcamaRowVm
{
    [Range(0, 100000000)]
    public double Tutar { get; set; }

    [Required]
    public string Aciklama { get; set; } = default!;
}

public class MusteriOdemeRowVm
{
    [Required]
    public string MusteriId { get; set; } = default!;

    [Required]
    public string Turu { get; set; } = default!;

    [Range(0, 100000000)]
    public double Tutar { get; set; }

    public DateTime Tarih { get; set; }
}

public class AlisFaturaRowVm
{
    [Required]
    public string Turu { get; set; } = default!;

    [Range(0, 100000)]
    public double Lt { get; set; }

    public int FisNo { get; set; }

    [Range(0, 100000000)]
    public double Tutar { get; set; }

    public DateTime Tarih { get; set; }
}
