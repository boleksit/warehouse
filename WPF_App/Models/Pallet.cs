
namespace WPF_App.Models;

public class Pallet
{
    public int Id { get; set; }
    public double Weight { get; set; }
    public Address Address { get; set; }
    public Client Client { get; set; }
    public Status Status { get; set; }
}