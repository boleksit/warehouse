namespace warehouse.Modify;

/// <summary>
/// Modify address
/// </summary>
public class ModifyAddress
{
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
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
    /// Phone
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Address type - available value: company, shipping
    /// </summary>
    public string AddressType { get; set; }
}