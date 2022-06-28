using System.Reflection.Metadata.Ecma335;

namespace warehouse.Properties;

public class AuthenticationSettings
{
    public string JwtKey { get; set; }
    public int JwtExpireDays{ get; set; }
    public string JwtIssuer { get; set; }
}