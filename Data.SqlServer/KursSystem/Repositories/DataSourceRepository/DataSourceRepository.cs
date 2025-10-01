using Data.SqlServer.Base;
using Data.SqlServer.KursSystem.Context;
using Data.SqlServer.KursSystem.Entities;

namespace Data.SqlServer.KursSystem.Repositories.DataSourceRepository;

public class DataSourceRepository(KursSystemContext myDbContext)
    : BaseRepository<DataSource>(myDbContext), IDataSourceRepository
{
}
