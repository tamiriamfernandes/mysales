using Microsoft.EntityFrameworkCore;
using MySales.Core.Enums;

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

        base.OnModelCreating(modelBuilder);
    }
}
