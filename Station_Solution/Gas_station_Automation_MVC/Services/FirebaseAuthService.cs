// Services/FirebaseAuthService.cs
using Gas_station_Automation_MVC.Models;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace Gas_station_Automation_MVC.Services
{
    public class FirebaseAuthService
    {
        private readonly FirestoreDb _firestore;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly ILogger<FirebaseAuthService> _logger;

        public FirebaseAuthService(
            FirestoreDb firestore,
            IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClientFactory,
            IConfiguration config,
            ILogger<FirebaseAuthService> logger)
        {
            _firestore = firestore;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _config = config;
            _logger = logger;
        }

        private sealed class SignInResponse
        {
            [JsonPropertyName("idToken")] public string IdToken { get; set; } = default!;
            [JsonPropertyName("localId")] public string LocalId { get; set; } = default!;
            [JsonPropertyName("email")] public string Email { get; set; } = default!;
            [JsonPropertyName("displayName")] public string? DisplayName { get; set; }
        }

        public async Task<(bool success, string message, User? user)> LoginAsync(string email, string password, bool rememberMe)
        {
            try
            {
                // 1) Firebase REST ile email/password doğrula -> UID al
                var apiKey = _config["Firebase:ApiKey"];
                if (string.IsNullOrWhiteSpace(apiKey))
                    return (false, "Firebase:ApiKey eksik", null);

                var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={apiKey}";
                var payload = new { email, password, returnSecureToken = true };

                var client = _httpClientFactory.CreateClient();
                var res = await client.PostAsJsonAsync(url, payload);

                if (!res.IsSuccessStatusCode)
                    return (false, "Email veya şifre hatalı", null);

                var signIn = await res.Content.ReadFromJsonAsync<SignInResponse>();
                if (signIn is null || string.IsNullOrWhiteSpace(signIn.LocalId))
                    return (false, "Firebase giriş yanıtı alınamadı", null);

                var uid = signIn.LocalId;

                // 2) Firestore'dan kullanıcı profilini oku (tek gerçek kaynak)
                var userRef = _firestore.Collection("users").Document(uid);
                var snap = await userRef.GetSnapshotAsync();

                if (!snap.Exists)
                    return (false, "Bu kullanıcı Firestore'da tanımlı değil (users/{uid}). Yönetici ile iletişime geçin.", null);

                var user = snap.ConvertTo<User>();
                user.Id = uid; // güvence

                // 3) Aktiflik kontrolü
                if (!user.IsActive)
                    return (false, "Hesap pasif. Yönetici ile iletişime geçin.", null);

                // 4) Email uyuşmazlığı kontrolü (isteğe bağlı ama iyi)
                if (!string.Equals(user.Email?.Trim(), signIn.Email?.Trim(), StringComparison.OrdinalIgnoreCase))
                    return (false, "Kullanıcı email uyuşmuyor (Firestore vs Auth).", null);

                // 5) Role normalize (veride Türkçe/büyük harf varsa düzelt)
                var normalizedRole = NormalizeRole(user.Role);
                if (normalizedRole is null)
                    return (false, $"Geçersiz rol: {user.Role}. Rol admin/moderator/customer olmalı.", null);

                if (!string.Equals(user.Role, normalizedRole, StringComparison.Ordinal))
                {
                    user.Role = normalizedRole;
                    await userRef.UpdateAsync(new Dictionary<string, object> { ["Role"] = normalizedRole });
                }
                else
                {
                    user.Role = normalizedRole;
                }

                // 6) LastLoginAt güncelle
                await userRef.UpdateAsync(new Dictionary<string, object>
                {
                    ["LastLoginAt"] = Timestamp.GetCurrentTimestamp()
                });

                // 7) Cookie session oluştur
                await CreateUserSession(user, rememberMe);

                _logger.LogInformation("Login OK. uid={Uid} role={Role}", uid, user.Role);
                return (true, "Giriş başarılı", user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login hatası: {Email}", email);
                return (false, "Giriş sırasında bir hata oluştu", null);
            }
        }

        private static string? NormalizeRole(string? role)
        {
            if (string.IsNullOrWhiteSpace(role)) return null;

            role = role.Trim().ToLowerInvariant();

            return role switch
            {
                "admin" or "administrator" or "yönetici" => "admin",
                "moderator" or "moderatör" => "moderator",
                "customer" or "müşteri" => "customer",
                _ => null
            };
        }

        private async Task CreateUserSession(User user, bool rememberMe)
        {
            var ctx = _httpContextAccessor.HttpContext
                ?? throw new InvalidOperationException("HttpContext null (cookie yazılamaz).");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.DisplayName),
                new Claim(ClaimTypes.Role, user.Role) // admin/moderator/customer
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var props = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.Add(rememberMe ? TimeSpan.FromDays(7) : TimeSpan.FromHours(4))
            };

            await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
        }

        public async Task LogoutAsync()
        {
            var ctx = _httpContextAccessor.HttpContext;
            if (ctx != null)
                await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
