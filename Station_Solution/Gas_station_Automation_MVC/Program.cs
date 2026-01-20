using FirebaseAdmin;
using Gas_station_Automation_MVC.Services;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// HTTP Services
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

// Firebase Admin SDK initialization
var credentialPath = builder.Configuration["Firebase:CredentialsPath"];
if (string.IsNullOrWhiteSpace(credentialPath) || !File.Exists(credentialPath))
    throw new InvalidOperationException($"Firebase:CredentialsPath eksik veya dosya yok: {credentialPath}");

var credential = GoogleCredential.FromFile(credentialPath);

try
{
    FirebaseApp.Create(new AppOptions { Credential = credential });
}
catch (ArgumentException) { }

// Firestore
var projectId = builder.Configuration["Firebase:ProjectId"];
if (string.IsNullOrWhiteSpace(projectId))
    throw new InvalidOperationException("Firebase:ProjectId eksik.");

builder.Services.AddSingleton(_ =>
    new FirestoreDbBuilder { ProjectId = projectId, Credential = credential }.Build()
);


// Authentication (Cookie)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = builder.Environment.IsDevelopment()
            ? CookieSecurePolicy.SameAsRequest
            : CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
    });

// Authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                c.Type == ClaimTypes.Role &&
                c.Value.Equals("admin", StringComparison.OrdinalIgnoreCase))));

    options.AddPolicy("ModeratorOrAdmin", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                c.Type == ClaimTypes.Role &&
                (c.Value.Equals("admin", StringComparison.OrdinalIgnoreCase) ||
                 c.Value.Equals("moderator", StringComparison.OrdinalIgnoreCase)))));

    options.AddPolicy("CustomerOnly", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                c.Type == ClaimTypes.Role &&
                c.Value.Equals("customer", StringComparison.OrdinalIgnoreCase))));
});

// Services
builder.Services.AddScoped<FirebaseAuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Debug routes for development
if (app.Environment.IsDevelopment())
{
    app.MapGet("/debug/auth", (HttpContext context) =>
    {
        var isAuthenticated = context.User.Identity?.IsAuthenticated ?? false;
        var name = context.User.Identity?.Name;
        var role = context.User.FindFirst(ClaimTypes.Role)?.Value;
        var uid = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var email = context.User.FindFirst(ClaimTypes.Email)?.Value;

        return Results.Json(new
        {
            Authenticated = isAuthenticated,
            Name = name,
            Role = role,
            UID = uid,
            Email = email
        });
    }).AllowAnonymous();
}

// Route mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// Dashboard routes
app.MapControllerRoute(
    name: "adminDashboard",
    pattern: "AdminDashboard/{action=Index}/{id?}",
    defaults: new { controller = "AdminDashboard" });

app.MapControllerRoute(
    name: "moderatorDashboard",
    pattern: "ModeratorDashboard/{action=Index}/{id?}",
    defaults: new { controller = "ModeratorDashboard" });

app.MapControllerRoute(
    name: "customerDashboard",
    pattern: "CustomerDashboard/{action=Index}/{id?}",
    defaults: new { controller = "CustomerDashboard" });

app.MapControllerRoute(
    name: "account",
    pattern: "Account/{action=Login}/{id?}",
    defaults: new { controller = "Account" });

app.Run();