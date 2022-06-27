using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

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
    [JsonIgnore] 
    public virtual AddressEntity Address { get; set; }
    [JsonIgnore] 
    public virtual ClientEntity Client { get; set; }
    [JsonIgnore] 
    public virtual PalletEntity Pallet { get; set; }
}
