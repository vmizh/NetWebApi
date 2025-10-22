using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.RegionRepository;

public class RegionRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_23>(contextRepository: repository), IRegionRepository
{
    
   
}
