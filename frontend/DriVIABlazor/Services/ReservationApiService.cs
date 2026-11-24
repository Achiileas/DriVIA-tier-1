using System.Net.Http.Json;
using DriVIABlazor.Models;


namespace DriVIABlazor.Services;

public class ReservationApiService
{
    private readonly HttpClient httpClient;

    public ReservationApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Reservation>> GetMyReservationsAsync()
    {
        await Task.CompletedTask;
        return new List<Reservation>();
    }
    
    public async Task<bool> CreateReservationAsync(
        ReservationCreateApiRequest request)
    {
        HttpResponseMessage response =
            await httpClient.PostAsJsonAsync(
                "api/customer/reservations", request);

        return response.IsSuccessStatusCode;
    }

}