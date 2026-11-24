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
            await httpClient.GetFromJsonAsync<List<Car>>("api/vehicles");
        
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
    
    public async Task<Car?> GetCarByIdAsync(long id)
    {
        return await httpClient.GetFromJsonAsync<Car>(
            $"api/vehicles/{id}");
    }
    
    public async Task<List<Car>> GetAvailableCarsAsync(
        int locationId,
        DateOnly pickupDate,
        DateOnly returnDate)
    {
        string url = $"api/vehicles/available" +
                     $"?locationId={locationId}" +
                     $"&pickupDate={pickupDate:yyyy-MM-dd}" +
                     $"&returnDate={returnDate:yyyy-MM-dd}";

        List<Car>? cars =
            await httpClient.GetFromJsonAsync<List<Car>>(url);

        return cars ?? new List<Car>();
    }
    
}

