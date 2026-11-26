
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

    private async Task<HttpResponseMessage> ExecuteRequestAsync(
        Func<Task<HttpResponseMessage>> request)
    {
        HttpResponseMessage response;

        try
        {
            response = await request();
        }
        catch (HttpRequestException)
        {
            throw new Exception(
                "Unable to connect to the service. Please try again later.");
        }
        catch (TaskCanceledException)
        {
            throw new Exception(
                "The request timed out. Please try again.");
        }

        if (!response.IsSuccessStatusCode)
        {
            string message =
                ApiErrorHelper.GetErrorMessage(response.StatusCode);

            response.Dispose();
            throw new Exception(message);
        }

        return response;
    }

    public async Task<List<Car>> GetAllCarsAsync()
    {
        using var response = await ExecuteRequestAsync(
            () => httpClient.GetAsync("api/vehicles"));

        var cars =
            await response.Content.ReadFromJsonAsync<List<Car>>();

        return cars ?? new List<Car>();
    }

    public async Task<bool> AddCarAsync(Car car)
    {
        using var response = await ExecuteRequestAsync(
            () => httpClient.PostAsJsonAsync("api/vehicles", car));

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCarAsync(Car car)
    {
        using var response = await ExecuteRequestAsync(
            () => httpClient.PutAsJsonAsync(
                $"api/vehicles/{car.Id}", car));

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCarAsync(long carId)
    {
        using var response = await ExecuteRequestAsync(
            () => httpClient.DeleteAsync($"api/vehicles/{carId}"));

        return response.IsSuccessStatusCode;
    }

    public async Task<Car?> GetCarByIdAsync(long id)
    {
        using var response = await ExecuteRequestAsync(
            () => httpClient.GetAsync($"api/vehicles/{id}"));

        return await response.Content.ReadFromJsonAsync<Car>();
    }

    public async Task<List<Car>> GetAvailableCarsAsync(
        int locationId,
        DateTime pickupDate,
        DateTime returnDate)
    {
        string url = $"api/vehicles/available" +
                     $"?locationId={locationId}" +
                     $"&pickupDate={pickupDate:yyyy-MM-ddTHH:mm:ss}" +
                     $"&returnDate={returnDate:yyyy-MM-ddTHH:mm:ss}";

        using var response = await ExecuteRequestAsync(
            () => httpClient.GetAsync(url));

        var cars =
            await response.Content.ReadFromJsonAsync<List<Car>>();

        return cars ?? new List<Car>();
    }
}
