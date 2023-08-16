using Microsoft.EntityFrameworkCore;
using MySales.Infrastructure.Contexts;

namespace MySales.Api.Configuration;

public static class ConfigureServicesExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionstring = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<MySalesContext>(options =>
            options.UseNpgsql(connectionstring)); 
    }
}
