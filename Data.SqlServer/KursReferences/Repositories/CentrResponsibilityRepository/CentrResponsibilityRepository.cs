using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.CentrResponsibilityRepository;

public class CentrResponsibilityRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_40>(contextRepository: repository), ICentrResponsibilityRepository
{
    
   
}
