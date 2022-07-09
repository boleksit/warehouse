using System.Reflection.Metadata.Ecma335;

namespace warehouse.Create;

/// <summary>
/// Create new Pallet
/// </summary>
public class CreatePallet
{
    /// <summary>
    /// Address Id
    /// </summary>
    public int AddressId { get; set; }
    /// <summary>
    /// Client Id
    /// </summary>
    public int ClientId { get; set; }
    /// <summary>
    /// Status Id
    /// </summary>
    public int StatusId { get; set; }
    /// <summary>
    /// List of boxes ids, separated by ";"
    /// </summary>
    public string packageIds { get; set; }
}