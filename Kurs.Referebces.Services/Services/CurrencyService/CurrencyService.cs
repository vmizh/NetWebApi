using System.Net;
using Azure;
using Common.Helper.API;
using Common.Helper.Extensions;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;
using Data.SqlServer.KursReferences.Repositories.CurrencyRepository;
using DTO.KursReferences.Currency;
using Kurs.References.Services.Services.Base;

namespace Kurs.References.Services.Services.CurrencyService;

public class CurrencyService(IKursReferencesBaseRepository<SD_301> repository, ICurrencyRepository currencyRepository)
    : KursReferenceBaseService<SD_301>(repository), ICurrencyService
{
    protected ICurrencyRepository currencyRepository = currencyRepository;

    protected override string RepositoryName => "Репозиторий справочника валют Курса";

    public async Task<APIResponse<List<CurrencyDto>>> GetAllFullAsync(APIRequest request,
        CancellationToken cancellationToken)
    {
        var result = new APIResponse<List<CurrencyDto>>()
        {
            IsSuccess = false
        };
        try
        {
            var lst = await repository.GetAllAsync(request.DbId, cancellationToken);
            var data = lst.Select(item => item.MapToCurrencyDto()).ToList();
            result.IsSuccess = true;
            result.Result = data;

            return result;
        }
        catch (Exception ex)
        {
            result.ErrorMessages = ex.ErrorTextList();
            result.StatusCode = HttpStatusCode.InternalServerError;
            return result;
        }
    }
}
