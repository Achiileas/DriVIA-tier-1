namespace DriVIABlazor.Models;

public class Car
{
//Hi Anushka, here I changed unique identifier of the car,
//matching the Java backend
    public long Id { get; set; }
    public string Model { get; set; } = "";
    public string Category { get; set; } = "";
    public string Location { get; set; } = "";
}