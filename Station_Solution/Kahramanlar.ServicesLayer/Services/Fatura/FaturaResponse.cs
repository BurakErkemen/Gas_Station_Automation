using Google.Protobuf.WellKnownTypes;

namespace Kahramanlar.ServicesLayer.Services.Fatura;

public record FaturaResponse(
    string Turu,
    int FisNo,
    double Lt,
    double Tutar,
    DateTime Tarih,
    DateTime CreatedAt
    );