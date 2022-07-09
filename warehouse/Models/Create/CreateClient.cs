namespace warehouse.Create;

/// <summary>
/// Create new Client
/// </summary>
public class CreateClient
{
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Phone
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Street
    /// </summary>
    public string Street { get; set; }
    /// <summary>
    /// Apartment number
    /// </summary>
    public string ApartmentNo { get; set; }
    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Postal Code
    /// </summary>
    public string PostalCode { get; set; }
    /// <summary>
    /// Address Type, available value: company, shipping
    /// </summary>
    public string AddressType { get; set; }
}