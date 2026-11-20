namespace DriVIABlazor.Models;

public class Reservation
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int VehicleId { get; set; }

    public string VehicleModel { get; set; } = "";

    public int LocationId { get; set; }

    public string LocationName { get; set; } = "";

    public DateOnly PickupDate { get; set; }

    public DateOnly ReturnDate { get; set; }

    public string Status { get; set; } = "";

    public int TotalPrice { get; set; }
}