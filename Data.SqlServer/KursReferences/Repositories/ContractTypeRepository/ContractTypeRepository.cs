using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.ContractTypeRepository;

public class ContractTypeRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_102>(repository), IContractTypeRepository
{
}
