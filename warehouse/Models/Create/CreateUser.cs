using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace warehouse.Create;

public class CreateUser
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Name { get; set; }
    [DefaultValue(3)]
    public int RoleId { get; set; } = 3; //default role id is 3 - user
}