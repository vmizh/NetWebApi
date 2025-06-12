using Common.Repositories;
using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using Data.SqlServer.KursSystem.Repositories.DataSourceRepository;
using DTO.KursSystemDTO;

namespace Kurs.System.Services.Services.DataSourceServices;

public class DataSourceService(IBaseRepository<DataSource> repository, IDataSourceRepository dsRepository)
    : BaseService<DataSource>(repository), IDataSourceService
{
    protected override string RepositoryName => "Репозиторий баз данных";
    private IDataSourceRepository DataSourceRepository = dsRepository;

}

public class DataSourceDtoService(IBaseRepository<DataSource> repository, IDataSourceRepository dsRepository)
    : BaseDtoService<DataSource,DataSourceDto>(repository), IDataSourceDtoService
{
    protected override string RepositoryName => "Репозиторий баз данных";
    private IDataSourceRepository DataSourceRepository = dsRepository;

}
