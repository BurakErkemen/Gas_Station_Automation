namespace WebSite.Services.Layer.AuthServices;

public interface IAuthService
{
    Task<string> Login(string email, string password);
}