using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.NomenklTypeRepository;

public class NomenklTypeRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_119>(contextRepository: repository), INomenklTypeRepository
{
    
   
}
