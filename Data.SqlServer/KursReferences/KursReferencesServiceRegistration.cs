using Common.Repositories;
using Data.SqlServer.Base;
using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;
using Data.SqlServer.KursReferences.Repositories.CurrencyRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.SqlServer.KursReferences;

public static class KursReferencesServiceRegistration
{
    public static IServiceCollection AddKursReferencesDataDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<KursReferenceContext>();
        services.AddSingleton<IKursReferenceContextRepository,KursReferenceContextRepository>();
        services.AddScoped<IKursReferencesBaseRepository<SD_301>, KursReferencesBaseRepository<SD_301>>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        
        return services;
    }
}
