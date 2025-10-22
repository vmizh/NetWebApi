using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.CashBoxRepository;

public class CashBoxRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_22>(contextRepository: repository), ICashBoxRepository
{
    
   
}
