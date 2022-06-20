using AutoMapper;
using Microsoft.EntityFrameworkCore;
using warehouse.Database;

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
}