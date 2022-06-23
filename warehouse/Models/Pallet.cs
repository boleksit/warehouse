using System.ComponentModel.DataAnnotations;
using warehouse.Entities;

namespace warehouse;

public class Pallet
{
    public int Id { get; set; }
    public int Weight { get; set; }
    public Address Address { get; set; }
    public Client Client { get; set; }
    public Status Status { get; set; }
}