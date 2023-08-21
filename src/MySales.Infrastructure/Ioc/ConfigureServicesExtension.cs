using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySales.Core.Repositories;
using MySales.Infrastructure.Contexts;
using MySales.Infrastructure.Repositories;

namespace MySales.Infrastructure.Ioc;

public static class ConfigureServicesExtension
{
    public static void AddServiceInfrastructure(this IServiceCollection services, string connectionstring)
    {

    }
}
