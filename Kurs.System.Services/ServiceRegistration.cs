using Kurs.System.Services.Services.DataSourceServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kurs.System.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IDataSourceService, DataSourceService>();
        return services;
    }
}
