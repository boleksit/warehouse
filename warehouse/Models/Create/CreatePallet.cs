using System.Reflection.Metadata.Ecma335;

namespace warehouse.Create;

public class CreatePallet
{
    public int AddressId { get; set; }
    public int ClientId { get; set; }
    public int StatusId { get; set; }
    public string packageIds { get; set; }
}