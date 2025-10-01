using Data.SqlServer.KursReferences.Entities;
using Kurs.References.Services.Services.Base;
using Kurs.References.Services.Services.CurrencyService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kurs.References.Services;

public static class KursReferenceServiceRegistration
{
    public static IServiceCollection AddKursReferenceServiceDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IKursReferencesBaseService<SD_301>, KursReferenceBaseService<SD_301>>();
        services.AddScoped<ICurrencyService, CurrencyService>();
        return services;
    }
}
