using Google.Cloud.Firestore;

namespace Kahramanlar.RepositoryLayer.Models.Kullanıcılar
{
    [FirestoreData]
    public class UserModel
    {
        [FirestoreProperty]
        public string UserId { get; set; } = Guid.NewGuid().ToString(); // Benzersiz Müşteri No

        [FirestoreProperty]
        public string UserName { get; set; } = default!;

        [FirestoreProperty]
        public string Phone { get; set; } = default!; // Giriş için genelde telefon kullanılır

        [FirestoreProperty]
        public string UserEmail { get; set; } = default!;

        // Şifreyi asla düz metin olarak saklama! Hashlenmiş olmalı.
        [FirestoreProperty]
        public string PasswordHash { get; set; } = default!;

        [FirestoreProperty]
        public double ToplamBorc { get; set; } = 0;

        // Müşteri mi yoksa Personel mi olduğunu ayırt etmek için
        [FirestoreProperty]
        public string Role { get; set; } = "Customer";

        // Hesabın aktiflik durumu
        [FirestoreProperty]
        public bool IsActive { get; set; } = true;

        [FirestoreProperty]
        public string? RefreshToken { get; set; }

        // Firestore'da Türkiye saatiyle (Formatlı) saklamak istediğin için
        [FirestoreProperty]
        public string CreatedAtStr { get; set; } = default!;

        [FirestoreProperty]
        public DateTime CreatedAt { get; set; }
    }
}
