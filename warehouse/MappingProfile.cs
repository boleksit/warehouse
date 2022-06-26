using AutoMapper;
using warehouse.Create;
using warehouse.Entities;
using warehouse.Modify;

namespace warehouse;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClientEntity, Client>();
        CreateMap<CreateClient, ClientEntity>()
            .ForMember(c => c.Addresses,
                s => s.MapFrom(dto => new List<AddressEntity>()
                    {new AddressEntity() {AddressType = "company", ApartmentNo = dto.ApartmentNo, City = dto.City, Street = dto.Street, Name = dto.Name, Phone = dto.Phone, PostalCode = dto.PostalCode}}));
        CreateMap<AddressEntity, Address>();
        CreateMap<CreateAddress, AddressEntity>();
        CreateMap<ModifyAddress, AddressEntity>();
        CreateMap<Address, AddressEntity>();
        CreateMap<BoxEntity, Box>();
        CreateMap<CreateBox, BoxEntity>();
        CreateMap<StatusEntity, Status>();

    }
}