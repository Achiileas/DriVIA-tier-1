using DriVIABlazor.Components;
using DriVIABlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();


// Registering the API service for communication with Java Tier 2
builder.Services.AddHttpClient<CarApiService>(client =>
{
    // Reading the backend URL from appsettings.json
    string baseUrl = builder.Configuration["JavaApi:BaseUrl"]
                     ?? throw new InvalidOperationException("Java API URL is missing.");

    client.BaseAddress = new Uri(baseUrl);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();