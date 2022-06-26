using System.ComponentModel.DataAnnotations;

namespace warehouse.Entities;

public class BoxEntity
{

    public int Id { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public double Weight { get; set; }
    
    public int? ClientId { get; set; }
    public int? AddressId { get; set; }
    public int? PalletId { get; set; }
    public int StatusId { get; set; }

    public virtual StatusEntity Status { get; set; }
    public virtual AddressEntity Address { get; set; }
    public virtual ClientEntity Client { get; set; }
    public virtual PalletEntity Pallet { get; set; }
}
