using Microsoft.EntityFrameworkCore;
using MySales.Model.Enums;

namespace MySales.Infrastructure.Contexts;

public class MySalesContext : DbContext
{
    public MySalesContext(DbContextOptions<MySalesContext> options) : base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MySalesContext).Assembly);
        modelBuilder.HasPostgresEnum<TypeMovement>();
        modelBuilder.HasPostgresEnum<TypePayment>();

        base.OnModelCreating(modelBuilder);
    }
}
