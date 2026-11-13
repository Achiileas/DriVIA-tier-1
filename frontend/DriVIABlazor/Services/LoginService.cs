using System.Net.Http.Json;
using DriVIABlazor.Models;

namespace DriVIABlazor.Services;

public class LoginService
{
    private readonly HttpClient httpClient;

    public LoginService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        using var response = await httpClient.PostAsJsonAsync(
            "auth/login", request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content
            .ReadFromJsonAsync<LoginResponse>();
    }
}