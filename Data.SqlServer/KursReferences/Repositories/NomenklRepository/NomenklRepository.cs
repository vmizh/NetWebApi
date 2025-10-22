using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.NomenklRepository;

public class NomenklRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_83>(contextRepository: repository), INomenklRepository
{
    
   
}
