using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.EmployeeRepository;

public class EmployeeRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<SD_2>(contextRepository: repository), IEmployeeRepository
{
    
   
}
