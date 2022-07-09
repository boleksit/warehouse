using System.ComponentModel.DataAnnotations;
using warehouse.Entities;

namespace warehouse;

/// <summary>
/// Pallet model
/// </summary>
public class Pallet
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Weight
    /// </summary>
    public double Weight { get; set; }
    /// <summary>
    /// Address
    /// </summary>
    public Address Address { get; set; }
    /// <summary>
    /// Client
    /// </summary>
    public Client Client { get; set; }
    /// <summary>
    /// Status
    /// </summary>
    public Status Status { get; set; }
}