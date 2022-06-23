namespace warehouse.Entities;

public class PalletEntity
{
    public int Id { get; set; }
    public int AddressId { get; set; }
    public int ClientId { get; set; }
    public int StatusId { get; set; }
    public virtual List<BoxEntity> Boxes { get; set; } 
    public virtual AddressEntity Address { get; set; }
    public virtual ClientEntity Client { get; set; }
}