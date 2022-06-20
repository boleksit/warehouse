using AutoMapper;
using warehouse.Entities;

namespace warehouse;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<ClientEntity, Client>();
        CreateMap<AddressEntity, Address>();
    }
}