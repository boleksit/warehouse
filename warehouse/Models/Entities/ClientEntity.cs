namespace warehouse.Entities;

public class ClientEntity
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public virtual List<AddressEntity> Addresses { get; set; }
}