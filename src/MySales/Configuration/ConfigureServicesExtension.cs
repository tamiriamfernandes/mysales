﻿using Microsoft.EntityFrameworkCore;
using MySales.Application.Contracts;
using MySales.Core.Repositories;
using MySales.Core.Services;
using MySales.Infrastructure.Contexts;
using MySales.Infrastructure.Repositories;

namespace MySales.Api.Configuration;

public static class ConfigureServicesExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<DbContext, MySalesContext>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProductService, ProductService>();
    }

    public static void AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionstring = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<MySalesContext>(options =>
            options.UseNpgsql(connectionstring));
    }

}
