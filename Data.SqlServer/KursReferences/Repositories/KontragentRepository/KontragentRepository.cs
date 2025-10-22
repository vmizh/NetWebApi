using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.KontragentRepository;

public class KontragentRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_43>(contextRepository: repository), IKontragentRepository
{
    
   
}
