using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using DTO.KursSystemDTO;

namespace Kurs.System.Services.Services.DataSourceServices;

public interface IDataSourceService : IBaseService<DataSource>
{
    
}

public interface IDataSourceDtoService : IBaseDtoService<DataSource,DataSourceDto>
{
    
}
