using System.Net.Http.Json;
using DriVIABlazor.Models;

namespace DriVIABlazor.Services;

public class RegistrationService : IRegistrationService
{
    private readonly HttpClient httpClient;

    public RegistrationService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<bool> RegisterAsync(RegistrationRequest request)
    {
        HttpResponseMessage response =
            await httpClient.PostAsJsonAsync("auth/register", request);

        return response.IsSuccessStatusCode;
    }
}
