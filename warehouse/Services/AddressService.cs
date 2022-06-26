using AutoMapper;
using Microsoft.EntityFrameworkCore;
using warehouse.Create;
using warehouse.Database;
using warehouse.Entities;
using warehouse.Modify;

namespace warehouse.Services;

public interface IAddressService
{
    string? Create(int clientId, CreateAddress address);
    Address? GetById(int clientId, int addressId);
    IEnumerable<Address>? GetAllByClientId(int clientId);
    bool RemoveAllByClientId(int clientId);
    bool RemoveAddressById(int clientId, int addressId);
    bool UpdateAddressById(int clientId, int addressId, ModifyAddress input);
}

public class AddressService : IAddressService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public AddressService(AppDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public string? Create(int clientId, CreateAddress address)
    {
        var client = GetClientById(clientId);
        if (client is null) return null;

        var addressEntity = _mapper.Map<AddressEntity>(address);
        _dbContext.Addresses.Add(addressEntity);
        _dbContext.SaveChanges();
        return $"/api/client/{clientId}/address/{addressEntity.Id}";
    }

    public Address? GetById(int clientId, int addressId)
    {
        var client = GetClientById(clientId);
        if (client is null) return null;

        var addressEntity = _dbContext.Addresses.FirstOrDefault(x => x.Id == addressId);
        if(addressEntity == null||addressEntity.ClientId != clientId) return null;
        return _mapper.Map<Address>(addressEntity);
    }
    public IEnumerable<Address>? GetAllByClientId(int clientId)
    {
        var client = GetClientById(clientId);
        return client is null ? null : _mapper.Map<List<Address>>(client.Addresses);
    }
    public bool RemoveAllByClientId(int clientId)
    {
        var client = GetClientById(clientId);
        if (client == null) return false;
        _dbContext.RemoveRange(client.Addresses);
        _dbContext.SaveChanges();
        return true;
    }

    public bool RemoveAddressById(int clientId, int addressId)
    {
        var client = GetClientById(clientId);
        if (client == null) return false;
        var address = _dbContext.Addresses.FirstOrDefault(address => address.Id == addressId);
        if (address == null||address.ClientId!= clientId) return false;
        _dbContext.Remove(address.Id);
        _dbContext.SaveChanges();
        return true;
    }

    public bool UpdateAddressById(int clientId, int addressId, ModifyAddress input)
    {
        var client = GetClientById(clientId);
        if (client == null) return false;
        var address = _dbContext.Addresses.FirstOrDefault(address => address.Id == addressId);
        if (address == null||address.ClientId!= clientId) return false;
        address.Name = input.Name;
        address.Street= input.Street;
        address.City = input.City;
        address.ApartmentNo = input.ApartmentNo;
        address.PostalCode = input.PostalCode;
        address.Phone = input.Phone;
        address.AddressType = input.AddressType;
        _dbContext.SaveChanges();
        return true;
    }

    private ClientEntity? GetClientById(int clientId)
    {
        var client = _dbContext
            .Clients
            .Include(c=>c.Addresses)
            .FirstOrDefault(x => x.Id == clientId);
        return client;
    }
    
}