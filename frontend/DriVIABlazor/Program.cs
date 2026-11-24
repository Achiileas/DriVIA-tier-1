
using Microsoft.AspNetCore.Components.Authorization;
using DriVIABlazor.Components;
using DriVIABlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient<CarApiService>(client =>
{
    string baseUrl = builder.Configuration["JavaApi:BaseUrl"]
                     ?? throw new InvalidOperationException("Java API URL is missing.");

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddHttpClient<LocationApiService>(client =>
{
    string baseUrl = builder.Configuration["JavaApi:BaseUrl"]
                     ?? throw new InvalidOperationException("Java API URL is missing.");

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddHttpClient<LoginService>(client =>
{
    string baseUrl = builder.Configuration["JavaApi:BaseUrl"]
                     ?? throw new InvalidOperationException("Java API URL is missing.");

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddHttpClient<ReservationApiService>(client =>
{
    string baseUrl = builder.Configuration["JavaApi:BaseUrl"]
                     ?? throw new InvalidOperationException("Java API URL is missing.");

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddHttpClient<IRegistrationService, RegistrationService>(client =>
{
    string baseUrl = builder.Configuration["JavaApi:BaseUrl"]
                     ?? throw new InvalidOperationException("Java API URL is missing.");

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/login";
    });

builder.Services.AddAuthorization();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<SimpleAuthService>();

builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<SimpleAuthService>());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
