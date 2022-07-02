using AccountService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Database;

public class AppDbContext:DbContext
{
    private string _connectionString =
        "Data Source=127.0.0.1,1433;Database=WarehouseDB;User Id=sa; Password=PassToSA!;";
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    
    

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
      optionsBuilder.UseSqlServer(_connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      modelBuilder.Entity<UserEntity>()
          .Property(b => b.Email)
          .IsRequired();
      modelBuilder.Entity<UserEntity>()
          .Property(b => b.Name)
          .IsRequired();
      modelBuilder.Entity<RoleEntity>()
          .Property(b => b.Name)
          .IsRequired();
  }
}