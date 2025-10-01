using Common.Repositories;
using Data.SqlServer.Base;
using Data.SqlServer.KursSystem.Context;
using Data.SqlServer.KursSystem.Entities;
using Data.SqlServer.KursSystem.Repositories.DataSourceRepository;
using Data.SqlServer.KursSystem.Repositories.KursMenu;
using Data.SqlServer.KursSystem.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.SqlServer.KursSystem;

public static class KursSystemServiceRegistration
{
    public static IServiceCollection AddKursSystemDataDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<KursSystemContext>(opt =>
            opt.UseSqlServer("name=SystemConnection"));

        services.AddScoped<IBaseRepository<DataSource>, BaseRepository<DataSource>>();
        services.AddScoped<IDataSourceRepository, DataSourceRepository>();

        services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IBaseRepository<KursMenuItem>, BaseRepository<KursMenuItem>>();
        services.AddScoped<IKursMenuRepository, KursMenuRepository>();

        return services;
    }
}
