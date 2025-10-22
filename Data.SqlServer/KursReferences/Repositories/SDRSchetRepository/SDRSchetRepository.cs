using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.SDRSchetRepository;

public class SDRSchetRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_303>(contextRepository: repository), ISDRSchetRepository
{
    
   
}
