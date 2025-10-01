using Azure;
using Common.Helper.API;
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

    public override async Task<APIResponse> GetAllAsync(APIRequest request, CancellationToken cancellationToken)
    {
        var res = await base.GetAllAsync(request, cancellationToken);
        switch (res.IsSuccess)
        {
            case false:
                return res;
        };
        var data = ((List<SD_301>)res.Result).Select(item => item.MapToCurrencyDto()).ToList();
        res.Result = data;

        return res;
    }
}
