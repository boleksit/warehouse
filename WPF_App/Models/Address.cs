namespace WPF_App.Models;

public class Address
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string ApartmentNo { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string AddressType { get; set; }
    
    public Address()
    {
        
    }
    // public Address(Client client = null, AdressType type = default, string name = null, string street = null, string apartmentNo = null, string city = null, string postalCode = null, string phone = null)
    // {
    //     Client = client;
    //     Type = type;
    //     Name = name;
    //     Street = street;
    //     ApartmentNo = apartmentNo;
    //     City = city;
    //     PostalCode = postalCode;
    //     Phone = phone;
    // }
}