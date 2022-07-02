namespace AccountService.Models.Create;

public class CreateUser
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Name { get; set; }
    public int RoleId { get; set; } = 3; //default role id is 3 - user
}