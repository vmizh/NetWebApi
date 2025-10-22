using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.SDRStateRepository;

public class SDRStateRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_99>(contextRepository: repository), ISDRStateRepository
{
    
   
}
