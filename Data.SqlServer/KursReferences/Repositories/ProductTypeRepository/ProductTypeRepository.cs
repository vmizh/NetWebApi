using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.ProductTypeRepository;

public class ProductTypeRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_50>(contextRepository: repository), IProductTypeRepository
{
    
   
}
