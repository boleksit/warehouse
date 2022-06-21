using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using warehouse.Create;
using warehouse.Database;
using warehouse.Entities;
using warehouse.Modify;

namespace warehouse.Services;

public interface IClientService
{
    IEnumerable<Client> GetAll();
    Client? GetById(int id);
    string CreateClient(CreateClient input);
    bool Delete(int id);
    bool Update(int id, ModifyClient input);
}

public class ClientService : IClientService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public ClientService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<Client> GetAll()
    {
        var clients = _mapper.Map<List<Client>>(_dbContext
            .Clients
            .Include(r=> r.Addresses)
            .ToList()
        );
        return clients;
    }

    public Client? GetById(int id)
    {
        var client = _dbContext
            .Clients
            .Include(r=>r.Addresses)
            .FirstOrDefault(c => c.Id == id);

        if (client is null)return null;
        return _mapper.Map<Client>(client);
    }

    public string CreateClient(CreateClient input)
    {
        var client = _mapper.Map<ClientEntity>(input);
        _dbContext.Clients.Add(client);
        _dbContext.SaveChanges();

        return $"/api/client/{client.Id}";
    }

    public bool Delete(int id)
    {
        var client = _dbContext
            .Clients
            .FirstOrDefault(c => c.Id == id);

        if (client is null) return false;
        _dbContext.Clients.Remove(client);
        _dbContext.SaveChanges(); 
        return true;
    }

    public bool Update(int id, ModifyClient input)
    {
        var client = _dbContext
            .Clients
            .FirstOrDefault(c => c.Id == id);

        if (client is null) return false;
        client.Email = input.Email;
        client.Phone = input.Phone;
        client.Name = input.Name;
        _dbContext.SaveChanges(); 
        return true;
    }
}