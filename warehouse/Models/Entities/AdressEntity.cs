using System.ComponentModel.DataAnnotations;

namespace warehouse;

public class AdressEntity
{
    [Key]
    public int Id { get; set; }
    public ClientEntity Client { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string ApartmentNo { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    
}