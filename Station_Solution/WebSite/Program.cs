using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebSite.Options;
using WebSite.Services.Layer.AuthServices;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var credentialPath = builder.Configuration["Firebase:ServiceAccountPath"];

        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile(credentialPath),
            ProjectId = builder.Configuration["Firebase:ProjectId"]
        });

        // Firestore init
        builder.Services.AddSingleton(_ =>
        {
            var projectId = builder.Configuration["Firebase:ProjectId"];
            return FirestoreDb.Create(projectId);
        });

        // Kayıtları ekleyin
        builder.Services.AddHttpClient();
        builder.Services.Configure<FirebaseAuthOptions>(builder.Configuration.GetSection("FirebaseAuth"));
        builder.Services.AddScoped<IAuthService, AuthService>();

        // Cookie Authentication (ASP.NET oturumu)
        builder.Services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(opt =>
            {
                opt.LoginPath = "/Auth/Login";
                opt.AccessDeniedPath = "/Auth/Login";
                opt.LogoutPath = "/Home/Index";
                // LogoutPath opsiyonel; Logout action’ını zaten elle çağırıyorsun

                opt.Cookie.Name = "WebSite.Auth";
                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(7);
            });

        builder.Services.AddAuthorization();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // ❗ sıralama önemli
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}