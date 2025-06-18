using Kurs.System.Services.Services.DataSourceServices;
using Kurs.System.Services.Services.MenuServices;
using Kurs.System.Services.Services.UserService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kurs.System.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IDataSourceService, DataSourceService>();
        services.AddScoped<IDataSourceDtoService, DataSourceDtoService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserDtoService, UserDtoService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IMenuDtoService, MenuDtoService>();
        return services;
    }
}
