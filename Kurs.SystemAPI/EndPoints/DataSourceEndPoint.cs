using Kurs.System.Services.Services.DataSourceServices;
using Serilog;

namespace Kurs.SystemAPI.EndPoints;

public static class DataSourceEndPoint
{
    public static void ConfigureDataSourceEndPoints(this WebApplication app)
    {
        var dsMap = app.MapGroup("/api/datasource");
        dsMap.MapGet("/all", GetDataSources).WithName("GetDataSources");
        dsMap.MapGet("/dto/all", GetDataDtoSources).WithName("GetDataDtoSources");
    }

    private static async Task<IResult> GetDataSources(IDataSourceService service)
    {
        Log.Logger.Information("Получение списка баз данных, зарегистрированных в курсе");
        return await service.GetAllAsync();
    }
    private static async Task<IResult> GetDataDtoSources(IDataSourceDtoService service)
    {
        Log.Logger.Information("Получение списка баз данных, зарегистрированных в курсе");
        return await service.GetAllAsync();
    }
}
