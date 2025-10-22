using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.NomenklMainRepository;

public class NomenkMainRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<NomenklMain>(contextRepository: repository), INomenklMainRepository
{
    
   
}
