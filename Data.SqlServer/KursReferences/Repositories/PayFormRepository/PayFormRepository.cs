using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.PayFormRepository;

public class PayFormRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_189>(contextRepository: repository), IPayFormRepository
{
    
   
}
