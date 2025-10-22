using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.CountryRepository;

public class CountryRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<COUNTRY>(repository), ICountryRepository
{
}
