namespace DriveVIA.Client.Models;

public class Car
{
    public  long Id { get; set; }

    public string Model { get; set; } = "";

    public string Category { get; set; } = "";

    public decimal Price { get; set; }

    public string Location { get; set; } = "";

    public string Gearbox { get; set; } = "";
}