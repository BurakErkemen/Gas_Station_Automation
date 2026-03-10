namespace Kahramanlar.ServicesLayer.Services.Calisan.Update;
public record UpdateCalisanRequest(
    string CalisanId,
    string Ad,
    string TcNo,
    string TelNo,
    DateTime IseGirisTarihi,
    DateTime? IstenCikisTarihi,
    bool IsActive
    );