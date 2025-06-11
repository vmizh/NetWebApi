using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursData.Context;

public class KursDataContext: DbContext
{
    public KursDataContext(DbContextOptions options):base(options)
    {
        
    }
}

