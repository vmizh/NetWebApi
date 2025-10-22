using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.WarehouseRepository;

public class WarehouseRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_27>(contextRepository: repository), IWarehouseRepository
{
    
   
}
