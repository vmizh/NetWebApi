using Common.Repositories;
using Data.SqlServer.KursSystem.Context;
using Data.SqlServer.KursSystem.Entities;

namespace Data.SqlServer.KursSystem.Repositories.DataSourceRepository;

public class DataSourceRepository(KursSystemContext dbContext)
    : BaseRepository<DataSource>(dbContext), IDataSourceRepository
{
}
