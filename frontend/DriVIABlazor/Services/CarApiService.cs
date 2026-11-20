using System.Net.Http.Json;
using DriVIABlazor.Models;

namespace DriVIABlazor.Services;

public class CarApiService
{
    private readonly HttpClient httpClient;

    public CarApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Car>> GetAllCarsAsync()
    {
        List<Car>? cars =
            await httpClient.GetFromJsonAsync<List<Car>>("api/cars");

        return cars ?? new List<Car>();
    }
    public async Task<bool> AddCarAsync(Car car)
    {
        HttpResponseMessage response =
            await httpClient.PostAsJsonAsync("api/cars", car);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCarAsync(Car car)
    {
        HttpResponseMessage response =
            await httpClient.PutAsJsonAsync(
                $"api/cars/{car.Id}", car);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCarAsync(long carId)
    {
        HttpResponseMessage response =
            await httpClient.DeleteAsync($"api/cars/{carId}");

        return response.IsSuccessStatusCode;
    }
}
