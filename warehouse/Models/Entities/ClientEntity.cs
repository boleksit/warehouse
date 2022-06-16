namespace warehouse.Entities;

public class ClientEntity
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Prone { get; set; }
    public virtual AddressEntity Address { get; set; }
}