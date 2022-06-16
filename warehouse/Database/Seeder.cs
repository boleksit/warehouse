using warehouse.Entities;

namespace warehouse.Database;

public class Seeder
{
    private readonly AppDbContext _dbContext;

    public Seeder(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public  void Seed()
    {
        if (!_dbContext.Database.CanConnect()) return;
        if (_dbContext.Clients.Any()) return;
        _dbContext.Clients.AddRange(GetClients());
        _dbContext.SaveChanges();
    }

    private  IEnumerable<ClientEntity> GetClients()
    {
        var clients = new List<ClientEntity>()
        {
            new ClientEntity()
            {
                Addresses = new List<AddressEntity>()
                {
                    new AddressEntity()
                    {
                        AddressType = "shipping",
                        Name = "Janusz Kowalski",
                        City = "Kraków",
                        Phone = "888888888",
                        PostalCode = "31-888",
                        Street = "Mariacka",
                        ApartmentNo = "5/4"
                    },
                    new AddressEntity()
                    {
                        AddressType = "company",
                        Name = "TestExPol",
                        City = "Kraków",
                        Phone = "187154154",
                        PostalCode = "31-800",
                        Street = "Warszawska",
                        ApartmentNo = "22"
                    },
                },
                Email = "biuro@client.pl",
                Name = "Janusz Kowalski",
                Phone = "888888888"
            }
        };
        return clients;
    }
}