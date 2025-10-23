using System.Net;
using Common.Helper.API;
using Data.SqlServer.KursReferences.Context;
using DTO.KursReferences.Currency;
using Kurs.References.Services.Services.CurrencyService;
using Serilog;

namespace Kurs.ReferencesAPI.EndPoints;

public static class CurrencyEndPoint
{
    public static void ConfigureCurrencyEndPoints(this WebApplication app)
    {
        var dsMap = app.MapGroup("/api/currency");
        dsMap.MapPost("/all", GetGurrencies).WithName("GetGurrencies");
    }

    private static async Task<IResult> GetGurrencies(APIRequest request,
        ICurrencyService service, IKursReferenceContextRepository contextRepository, CancellationToken cancelToken)
    {
        Log.Logger.Information($"Получение списка всех валют в БД {contextRepository.GetContextName(request.DbId)}");

        APIResponse response = new APIResponse()
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.InternalServerError
        };
        try
        {
            response = await ((CurrencyService)service).GetAllAsync(request, cancelToken);
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }
}
