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
}