namespace Kahramanlar.ServicesLayer.Services.Calisan.Create;

public record CreateCalisanRequest(
    string Adı,
    string TelNo,
    string TcNo,
    DateTime IseGirisTarihi);