namespace AccountService.Models.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
    public string Name { get; set; }

    public virtual RoleEntity Role { get; set; }
}