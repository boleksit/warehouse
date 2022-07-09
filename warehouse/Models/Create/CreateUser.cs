using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace warehouse.Create;
/// <summary>
/// Model for Creating users
/// </summary>
public class CreateUser
{
    /// <summary>
    /// User Email
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// User Password
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// Confirmation of the password. Must mach the password
    /// </summary>
    public string ConfirmPassword { get; set; }
    /// <summary>
    /// Name of the user
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// User role. 1 = admin, 2 = employee, 3 = user. Default value - 3
    /// </summary>
    [DefaultValue(3)]
    public int RoleId { get; set; } = 3; //default role id is 3 - user
}