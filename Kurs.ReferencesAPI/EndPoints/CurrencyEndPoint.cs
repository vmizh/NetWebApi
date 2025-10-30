using System.Net;
using System.Text.Json;
using Common.Helper.API;
using Common.Helper.Extensions;
using Data.SqlServer.KursReferences.Context;
using Kurs.References.Services.Services.CurrencyService;
using Newtonsoft.Json;
using Serilog;

namespace Kurs.ReferencesAPI.EndPoints;

public static class CurrencyEndPoint
{
    public static void ConfigureCurrencyEndPoints(this WebApplication app)
    {
        var dsMap = app.MapGroup("/api/currency");
        dsMap.MapPost("/all", GetGurrencies).WithName("GetGurrencies");
        dsMap.MapPost("/", GetCurrency).WithName("GetGurrency");
        dsMap.MapPost("/list", GetListCurrencies).WithName("GetListCurrencies");
        dsMap.MapPost("/find", FindCurrencies).WithName("FindCurrencies");
    }

    private static async Task<IResult> FindCurrencies(APIRequest request,ICurrencyService service,
        IKursReferenceContextRepository contextRepository, CancellationToken cancelToken)
    {
        var response = new APIResponse
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.InternalServerError
        };
        try
        {
            response = await ((CurrencyService)service).GetListAsync(request, cancelToken);
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            Log.Logger.Error($"/api/currency/list {ex.ErrorText()}");
            return APIResponse.ReturnError(response, ex,Log.Logger);
        }
    }

    private static async Task<IResult> GetListCurrencies(APIRequest request,
        ICurrencyService service, IKursReferenceContextRepository contextRepository, CancellationToken cancelToken)
    {
        var response = new APIResponse
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.InternalServerError
        };
        try
        {
            if(request is { Id: null })
            {
                Log.Logger.Error("/api/currency/list Не передан список ключей");
                return APIResponse.ReturnError(response, new ArgumentException("Не передан список ключей"),
                    Log.Logger);
            }
            response = await ((CurrencyService)service).GetListAsync(request, cancelToken);
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            Log.Logger.Error($"/api/currency/list {ex.ErrorText()}");
            return APIResponse.ReturnError(response, ex,Log.Logger);
        }

       
    }

    private static async Task<IResult> GetCurrency(APIRequest request,
        ICurrencyService service, IKursReferenceContextRepository contextRepository, CancellationToken cancelToken)
    {
        var response = new APIResponse
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.InternalServerError
        };
        if (request is { Id: null })
        {
            Log.Logger.Error("В /api/currency/ передан не правильный параметр.");
            APIResponse.ReturnError(response, new ArgumentException("В /api/currency/ передан не правильный параметр."), Log.Logger);
        }
        Log.Logger.Information($"Получение валюты в БД {contextRepository.GetContextName(request.DbId)} id: {request.Id}");
        try
        {
           
            response = await ((CurrencyService)service).GetByIdAsync(request, cancelToken);
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            Log.Logger.Error($"/api/currency/list {ex.ErrorText()}");
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }

    }

    private static async Task<IResult> GetGurrencies(APIRequest request,
        ICurrencyService service, IKursReferenceContextRepository contextRepository, CancellationToken cancelToken)
    {
        Log.Logger.Information($"Получение списка всех валют в БД {contextRepository.GetContextName(request.DbId)}");

        var response = new APIResponse
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
