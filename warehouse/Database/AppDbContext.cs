using Microsoft.EntityFrameworkCore;
using warehouse.Entities;

namespace warehouse.Database;

public class AppDbContext:DbContext
{
    private string _connectionString =
        "Data Source=127.0.0.1,1433;Database=WarehouseDB;User Id=sa; Password=PassToSA!;";
    
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<BoxEntity> Boxes { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
      optionsBuilder.UseSqlServer(_connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      modelBuilder.Entity<BoxEntity>()
          .Property(b => b.Length)
          .IsRequired()
          .HasMaxLength(100);
      modelBuilder.Entity<BoxEntity>()
          .Property(b => b.Width)
          .IsRequired()
          .HasMaxLength(100);
      modelBuilder.Entity<BoxEntity>()
          .Property(b => b.Height)
          .IsRequired()
          .HasMaxLength(100);
      // modelBuilder.Entity<BoxEntity>()
      //     .Property(b => b.ClientId)
      //     .IsRequired();

  }
}