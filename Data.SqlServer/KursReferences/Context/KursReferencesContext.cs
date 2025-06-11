using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursReferences.Context;

public class KursReferencesContext: DbContext
{
    public KursReferencesContext(DbContextOptions options):base(options)
    {
        
    }
}
