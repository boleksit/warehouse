
namespace WPF_App.Models;

public class Box
{
    public int Id { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public double Weight { get; set; }
    public Status Status { get; set; }
    public Client Client { get; set; }
    public Address Address { get; set; }
    public Pallet Pallet { get; set; }
}