using System.Diagnostics.CodeAnalysis;
using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.CurrencyRepository;

[SuppressMessage("ReSharper", "ConvertTypeCheckPatternToNullCheck")]
public class CurrencyRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_301>(repository), ICurrencyRepository
{
    
}
