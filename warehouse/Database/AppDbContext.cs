using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace warehouse.Database;

public class AppDbContext:DbContext
{
    public DbSet<AdressEntity> Adresses { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
        {
            options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });
        base.OnConfiguring(optionsBuilder);
    }
}