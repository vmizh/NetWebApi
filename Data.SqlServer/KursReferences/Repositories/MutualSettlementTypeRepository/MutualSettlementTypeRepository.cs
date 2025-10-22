using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.MutualSettlementTypeRepository;

public class MutualSettlementTypeRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_111>(contextRepository: repository), IMutualSettlementTypeRepository
{
    
   
}
