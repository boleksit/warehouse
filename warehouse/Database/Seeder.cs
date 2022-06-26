﻿using warehouse.Entities;

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
        var changes = false;
        if (!_dbContext.Database.CanConnect()) return;
        if (!_dbContext.Status.Any())
        {
            _dbContext.Status.AddRange(GetStatus());
            _dbContext.SaveChanges();
        }
        if (!_dbContext.Clients.Any())
        {
            _dbContext.Clients.AddRange(GetClients());
            _dbContext.SaveChanges();
        }
        
    }

    private  IEnumerable<ClientEntity> GetClients()
    {
        var clients = new List<ClientEntity>()
        {
            new()
            {
                Addresses = new List<AddressEntity>()
                {
                    new()
                    {
                        AddressType = "shipping",
                        Name = "Janusz Kowalski",
                        City = "Kraków",
                        Phone = "888888888",
                        PostalCode = "31-888",
                        Street = "Mariacka",
                        ApartmentNo = "5/4"
                    },
                    new()
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
                Phone = "888888888",
               
                Boxes = new List<BoxEntity>()
                {
                    new()
                    {
                        ClientId = 1,
                        Height = 60,
                        Width = 40,
                        Length = 50,
                        Weight = 31,
                        StatusId = 1
                    }
                }
            }
        };
        return clients;
    }
    private IEnumerable<StatusEntity> GetStatus()
    {
        var statuses = new List<StatusEntity>()
        {
            new("prepared"),
            new("in transit"),
            new("in delivery"),
            new("delivered")
        };
        return statuses;
    }

    
}