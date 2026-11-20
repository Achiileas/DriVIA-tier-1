namespace DriVIABlazor.Models;

public class Car
{
    public long Id { get; set; }
    public string RegistrationNo { get; set; } = "";
    public string Model { get; set; } = "";
    public DateOnly ProductionDate { get; set; }
    public int Horsepower { get; set; }
    public string Category { get; set; } = "";
    public string Gearbox { get; set; } = "";
    public int PricePerDay { get; set; }
    public string Status { get; set; } = "";
    public int LocationId { get; set; }
    public string LocationName { get; set; } = "";

    public decimal Price => PricePerDay;
    public string Location => LocationName;
}