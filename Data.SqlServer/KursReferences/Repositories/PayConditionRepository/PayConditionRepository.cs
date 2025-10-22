using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.PayConditionRepository;

public class PayConditionRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_179>(contextRepository: repository), IPayConditionRepository
{
    
   
}
