using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using warehouse.Entities;

namespace warehouse.Database;

public class Seeder
{
    private readonly AppDbContext _dbContext;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;

    public Seeder(AppDbContext dbContext, IPasswordHasher<UserEntity> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }
    public  void Seed()
    {
        Console.WriteLine("Appling migrations..");
        _dbContext.Database.Migrate();
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
        if (!_dbContext.Roles.Any())
        {
            _dbContext.Roles.AddRange(GetRoles());
            _dbContext.SaveChanges();
        }
        if (!_dbContext.Boxes.Any())
        {
            _dbContext.Boxes.AddRange(GetBoxes());
            _dbContext.SaveChanges();
        }
        if (!_dbContext.Users.Any())
        {
            _dbContext.Users.AddRange(GetUsers());
            _dbContext.SaveChanges();
        }
        
    }

    private IEnumerable<RoleEntity> GetRoles()
    {
        var roles = new List<RoleEntity>()
        {
            new RoleEntity
            {
                Name = "Admin"
            },
            new RoleEntity
            {
                Name = "Employee"
            },
            new RoleEntity
            {
                Name = "User"
            }
        };
        return roles;
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
                
            }
        };
        return clients;
    }

    private IEnumerable<BoxEntity> GetBoxes()
    {
        var boxes = new List<BoxEntity>()
        {
            new()
            {
                ClientId = 1,
                AddressId = 1,
                Height = 60,
                Width = 40,
                Length = 50,
                Weight = 31,
                StatusId = 1
            },
            new()
            {
                ClientId = 1,
                AddressId = 2,
                Height = 80,
                Width = 20,
                Length = 15,
                Weight = 18,
                StatusId = 2
            },
            new()
            {
                ClientId = 1,
                AddressId = 1,
                Height = 200,
                Width = 10,
                Length = 10,
                Weight = 1,
                StatusId = 3
            }
        };
        return boxes;
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
    
    private IEnumerable<UserEntity> GetUsers()
    {
        var users = new List<UserEntity>();
        var user = new UserEntity()
        {
            Email = "admin@test.com",
            Name = "Admin",
            RoleId = 1
        };
        user.PasswordHash=_passwordHasher.HashPassword(user, "admin!");
        users.Add(user);
        return users;
    }
    
}