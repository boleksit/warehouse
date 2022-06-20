using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using warehouse.Creation;
using warehouse.Database;
using warehouse.Entities;

namespace warehouse.Services;

public class ClientService
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
}