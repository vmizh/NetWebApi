using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.BankAccount;

public interface IBankAccountRepository
{
   
}
 public class BankAccounRepository(IKursReferenceContextRepository repository)
        : KursReferencesBaseRepository<SD_114>(contextRepository: repository), IBankAccountRepository
    {
    
   
    } 
