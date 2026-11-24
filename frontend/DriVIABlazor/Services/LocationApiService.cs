using System.Net.Http.Json;
using DriVIABlazor.Models;

namespace DriVIABlazor.Services;

public class LocationApiService
{
    private readonly HttpClient httpClient;

    public LocationApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Location>> GetAllLocationsAsync()
    {
        List<Location>? locations =
            await httpClient.GetFromJsonAsync<List<Location>>(
                "api/locations");

        return locations ?? new List<Location>();
    }
}