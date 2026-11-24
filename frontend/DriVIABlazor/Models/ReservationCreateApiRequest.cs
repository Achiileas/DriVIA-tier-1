namespace DriVIABlazor.Models;

public class ReservationCreateApiRequest
{
    public int CustomerId { get; set; }

    public int VehicleId { get; set; }

    public DateOnly PickupDate { get; set; }

    public DateOnly ReturnDate { get; set; }
}