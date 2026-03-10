namespace Kahramanlar.ServicesLayer.Services.Calisan;

public record CalisanResponse(
    string Ad,
    string TelNo,
    string TcNo,
    bool IsActive,
    DateTime IseGirisTarihi,
    DateTime? IsCikisTarihi,
    DateTime CreatedAt
    );