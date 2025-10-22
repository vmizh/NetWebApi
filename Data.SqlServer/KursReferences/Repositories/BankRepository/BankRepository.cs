using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.BankRepository;

public class BankRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_44>(contextRepository: repository), IBankRepository
{
    
   
}
