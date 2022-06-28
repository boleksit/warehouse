using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using warehouse.Create;
using warehouse.Database;
using warehouse.Entities;
using warehouse.Properties;

namespace warehouse.Services;

public interface IAccountService
{
    void RegisterUser(CreateUser input);
    string GenerateJwt(LoginUser input);
}

public class AccountService : IAccountService
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;
    private readonly AuthenticationSettings _authenticationSettings;

    public AccountService(AppDbContext context, IPasswordHasher<UserEntity> passwordHasher, AuthenticationSettings authenticationSettings)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _authenticationSettings = authenticationSettings;
    }

    public void RegisterUser(CreateUser input)
    {
        var user = new UserEntity()
        {
            Email = input.Email,
            Name = input.Name,
            RoleId = input.RoleId
        };
        user.PasswordHash=_passwordHasher.HashPassword(user, input.Password);
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public string GenerateJwt(LoginUser input)
    {
        var user = _context.Users.Include(x=>x.Role)
            .FirstOrDefault(u => u.Email == input.Email);
        if (user is null)
        {
            return "Invalid username or password";
        }
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, input.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            return "Invalid username or password";
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name.ToString()),
            new Claim(ClaimTypes.Role, user.Role.Name.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

        var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: cred);

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}