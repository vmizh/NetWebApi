using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using DTO.KursSystemDTO;
using Microsoft.AspNetCore.Http;

namespace Kurs.System.Services.Services.UserService;

public interface IUserService : IBaseService<User>
{
}

public interface IUserDtoService : IBaseDtoService<User, UserDto>
{
    Task<IResult> GetByNameAsync(string name);
}
