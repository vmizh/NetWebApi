using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.KontragentCategoryRepository;

public class KontragentCategoryRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<UD_43>(contextRepository: repository), IKontragentCategoryRepository
{
    
   
}
