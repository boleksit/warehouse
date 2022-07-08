using System.ComponentModel;

namespace warehouse.Create;

public class LoginUser
{
    [DefaultValue("admin@test.com")]
    public string Email { get; set; }
    [DefaultValue("admin!")]
    public string Password { get; set; }
}