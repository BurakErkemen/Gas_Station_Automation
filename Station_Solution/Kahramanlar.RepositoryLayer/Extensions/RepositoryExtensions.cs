using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Kahramanlar.RepositoryLayer.Models.Faturalar;
using Kahramanlar.RepositoryLayer.Models.Kullanıcılar;

namespace Kahramanlar.RepositoryLayer.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            // appsettings.json dosyasından FirebaseCredentialPath değerini al
            string firebaseCredentialPath = configuration["FirebaseCredentialPath"]!;

            // FirebaseDbContext'i DI Container ekleme
            services.AddSingleton<FirebaseDbContext>(provider => new FirebaseDbContext(firebaseCredentialPath));

            services.AddScoped<IFaturaRepository, FaturaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();



            return services;
        }
    }
}
