namespace Kahramanlar.ServicesLayer.Services.Fatura.Create;

public record CreateFaturaRequest(
    string Turu,
    int FisNo,
    double Lt,
    double Tutar,
    DateTime Tarih
    );