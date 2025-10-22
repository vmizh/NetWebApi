using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.DeliveryRepository;

public class DeliveryRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_103>(repository), IDeliveryRepository
{
}
