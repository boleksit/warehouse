using System.ComponentModel.DataAnnotations;

namespace warehouse.Create;

public class CreateUser
{
    [Required]
    public string Email { get; set; }
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
    public string Name { get; set; }
    public int RoleId { get; set; } = 3; //default role id is 3 - user
}