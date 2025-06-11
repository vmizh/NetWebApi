using Common.Repositories;
using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using Data.SqlServer.KursSystem.Repositories.DataSourceRepository;

namespace Kurs.System.Services.Services.DataSourceServices;

public class DataSourceService(IBaseRepository<DataSource> repository, IDataSourceRepository dsRepository)
    : BaseService<DataSource>(repository), IDataSourceService
{
    protected override string RepositoryName => "Репозиторий баз данных";
    private IDataSourceRepository DataSourceRepository = dsRepository;

}
