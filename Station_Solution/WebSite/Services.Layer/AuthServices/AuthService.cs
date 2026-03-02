using Firebase.Auth;
using Microsoft.Extensions.Options;
using WebSite.Options;

namespace WebSite.Services.Layer.AuthServices;

public class AuthService : IAuthService
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public AuthService(IOptions<FirebaseAuthOptions> options, IHttpClientFactory httpClientFactory)
    {
        _apiKey = options.Value.ApiKey;
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<string> Login(string email, string password)
    {
        try
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(_apiKey));
            var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

            return auth.FirebaseToken;
        }
        catch (FirebaseAuthException ex)
        {
            // Firebase'den gelen teknik hata mesajlarını kullanıcı dostu mesajlara çeviriyoruz
            var message = ex.Reason switch
            {
                AuthErrorReason.WrongPassword => "Girdiğiniz şifre hatalı. 🔑",
                AuthErrorReason.UnknownEmailAddress => "Bu e-posta adresi ile kayıtlı bir kullanıcı bulunamadı. 📧",
                AuthErrorReason.UserDisabled => "Hesabınız askıya alınmış. Lütfen destekle iletişime geçin. 🚫",
                _ => "Giriş yapılırken beklenmedik bir hata oluştu. Lütfen tekrar deneyin. ⚠️"
            };

            throw new Exception(message);
        }
        catch (Exception)
        {
            throw new Exception("Sistem kaynaklı bir hata oluştu. 🖥️");
        }
    }
}