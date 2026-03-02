namespace Kahramanlar.ServicesLayer.Services.Fatura.Update;

public record UpdateFaturaRequest(
    string FaturaId,
    string Turu,
    int FisNo,
    double Lt,
    double Tutar,
    DateTime Tarih
    );