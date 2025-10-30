using System.Net;
using Common.Helper.API;
using Common.Helper.Extensions;
using Common.Repositories.Specification;
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
        var result = new APIResponse<List<CurrencyDto>>
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

    public override async Task<APIResponse> FindAsync(APIRequest request, CancellationToken cancelToken)
    {
        var result = new APIResponse
        {
            IsSuccess = false
        };
        if (request.RequestData is not string s || string.IsNullOrEmpty(s))
        {
            result.ErrorMessages.Add("Наименование валюты пустое");
            return result;
        }
        try
        {
            var spec = new CurrencyFindNameSpecification((string)request.RequestData);
            var data = await repository.FindAsync(request.DbId, spec, cancelToken);
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

public class CurrencyFindNameSpecification : Specification<SD_301>
{
    public CurrencyFindNameSpecification(string name)
    {
        AddFilteringQuery(_ => _.CRS_NAME.ToLower().Contains(name.ToLower()));
    }
}
