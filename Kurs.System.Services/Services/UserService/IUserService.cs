using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using DTO.KursSystemDTO.User;
using Microsoft.AspNetCore.Http;

namespace Kurs.System.Services.Services.UserService;

public interface IUserService : IBaseService<User>
{
}

public interface IUserDtoService : IBaseDtoService<User, UserDto>
{
    Task<IResult> GetByNameAsync(string name);
    Task<IResult> GetByNameFullAsync(string name, Guid dbId);
    Task<IResult> GetFullByIdAsync(Guid userId, Guid dbId);
}
