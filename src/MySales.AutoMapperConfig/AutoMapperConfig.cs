using Microsoft.Extensions.DependencyInjection;
using MySales.AutoMapperConfig.Profiles;

namespace MySales.AutoMapperConfig;

public static class AutoMapperConfig
{
    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        if(services is null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(
                typeof(ProductProfile));
    }
}
