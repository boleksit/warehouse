namespace warehouse.Create;

public class CreateAddress
{
    /// <summary>
    /// Address name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Street
    /// </summary>
    public string Street { get; set; }
    /// <summary>
    /// Appartment Number
    /// </summary>
    public string ApartmentNo { get; set; }
    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Postal code
    /// </summary>
    public string PostalCode { get; set; }
    /// <summary>
    /// Phone number
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// Address type - available value: company, shipping
    /// </summary>
    public string AddressType { get; set; }
}