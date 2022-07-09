using System.ComponentModel.DataAnnotations;

namespace warehouse;

/// <summary>
/// Box model
/// </summary>
public class Box
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Length
    /// </summary>
    public int Length { get; set; }
    /// <summary>
    /// Width
    /// </summary>
    public int Width { get; set; }
    /// <summary>
    /// Height
    /// </summary>
    public int Height { get; set; }
    /// <summary>
    /// Weight
    /// </summary>
    public double Weight { get; set; }
    /// <summary>
    /// Status
    /// </summary>
    public Status Status { get; set; }
    /// <summary>
    /// Client
    /// </summary>
    public Client Client { get; set; }
    /// <summary>
    /// Address
    /// </summary>
    public Address Address { get; set; }
    /// <summary>
    /// Pallet
    /// </summary>
    public Pallet Pallet { get; set; }
}