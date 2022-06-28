using warehouse.Create;
using warehouse.Database;
using warehouse.Entities;

namespace warehouse.Services;

public interface IAccountService
{
    void RegisterUser(CreateUser input);
}

public class AccountService : IAccountService
{
    private readonly AppDbContext _context;

    public AccountService(AppDbContext context)
    {
        _context = context;
    }

    public void RegisterUser(CreateUser input)
    {
        var user = new UserEntity()
        {
            Email = input.Email,
            Name = input.Name,
            RoleId = input.RoleId,

        };
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}