namespace DriVIABlazor.Models;

public class CreateReservationRequest
{
    public long VehicleId { get; set; }

    public DateTime PickupDate { get; set; }

    public DateTime ReturnDate { get; set; }
}