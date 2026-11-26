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
        HttpResponseMessage response;

        try
        {
            response = await httpClient.PostAsJsonAsync(
                "api/customer/reservations", request);
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

        using (response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    ApiErrorHelper.GetErrorMessage(response.StatusCode));
            }

            return true;
        }
    }
}