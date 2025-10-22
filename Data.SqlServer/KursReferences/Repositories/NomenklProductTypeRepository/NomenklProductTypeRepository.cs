using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.NomenklProductTypeRepository;

public class NomenklProductTypeRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_77>(contextRepository: repository), INomenklProductTypeRepository
{
    
   
}
