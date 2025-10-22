using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.UnitRepository;

public class UnitRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_175>(contextRepository: repository), IUnitRepository
{
    
   
}
