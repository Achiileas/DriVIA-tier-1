using System.Net.Http.Json;
using DriVIABlazor.Models;

namespace DriVIABlazor.Services;

public class CarApiService
{
    private readonly HttpClient httpClient;

    // Constructor receives HttpClient through dependency injection
    public CarApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    // Retrieves all cars from the Java REST API
    public async Task<List<Car>> GetAllCarsAsync()
    {
        // Sends GET request to the cars endpoint
        List<Car>? cars = await httpClient.GetFromJsonAsync<List<Car>>(
            "api/cars"
        );

        // Returns an empty list if the response is null
        return cars ?? new List<Car>();
    }
}