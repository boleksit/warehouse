using System.ComponentModel.DataAnnotations;
using warehouse.Entities;

namespace warehouse;

public class AddressEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string ApartmentNo { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public int ClientId { get; set; }
    
    
}