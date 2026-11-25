namespace DriVIABlazor.Models;

public class ReservationCreateApiRequest
{
    public int CustomerId { get; set; }

    public int VehicleId { get; set; }

    public DateTime PickupDate { get; set; }

    public DateTime ReturnDate { get; set; }
}