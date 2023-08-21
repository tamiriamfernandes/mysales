using Microsoft.EntityFrameworkCore;
using MySales.Application.Contracts.Repositories;
using MySales.Application.Contracts.UseCases;
using MySales.Application.Profiles;
using MySales.Application.UseCases;
using MySales.Infrastructure.Contexts;
using MySales.Infrastructure.Repositories;

namespace MySales.Api.Configuration;

public static class ConfigureServicesExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<DbContext, MySalesContext>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProductUseCase, ProductUseCase>();
    }

    public static void AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionstring = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<MySalesContext>(options =>
            options.UseNpgsql(connectionstring));
    }

    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(
                typeof(ProductProfile));
    }
}
