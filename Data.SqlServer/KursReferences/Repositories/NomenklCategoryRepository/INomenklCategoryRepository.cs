using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.NomenklCategoryRepository;

public interface INomenklCategoryRepository
{
    
}

public class NomenklCategoryRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_82>(contextRepository: repository), INomenklCategoryRepository
{
    
   
}
