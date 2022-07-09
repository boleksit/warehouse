using System.ComponentModel;

namespace warehouse.Create;

/// <summary>
/// Login user
/// </summary>
public class LoginUser
{
    /// <summary>
    /// Email
    /// </summary>
    [DefaultValue("admin@test.com")]
    public string Email { get; set; }
    /// <summary>
    /// Password
    /// </summary>
    [DefaultValue("admin!")]
    public string Password { get; set; }
}