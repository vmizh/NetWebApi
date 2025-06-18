using System.Net;
using Common.Helper.API;
using Common.Repositories;
using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using Data.SqlServer.KursSystem.Repositories.UserRepository;
using DTO.Common;
using DTO.KursSystemDTO.User;
using Mapster;
using Microsoft.AspNetCore.Http;
using Log = Serilog.Log;

namespace Kurs.System.Services.Services.UserService;

public class UserService(IBaseRepository<User> repository, IUserRepository userRepository)
    : BaseService<User>(repository), IUserService
{
    private IUserRepository userRepository = userRepository;
    protected override string RepositoryName => "Репозиторий пользователей Курса";
}

public class UserDtoService(IBaseRepository<User> repository, IUserRepository userRepository)
    : BaseDtoService<User, UserDto>(repository), IUserDtoService
{
    protected override string RepositoryName => "Репозиторий пользователей Курса";

    public async Task<IResult> GetByNameAsync(string name)
    {
        Log.Logger.Information($"{RepositoryName}. Получение пользователя'{name})'");
        var response = new APIResponse();
        try
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var item = await userRepository.GetByName(name);
                if (item is not null)
                {
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Result = item.Adapt<UserDto>();
                    return Results.Ok(response);
                }
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public async Task<IResult> GetFullByIdAsync(Guid id)
    {
        Log.Logger.Information($"{RepositoryName}. Получение пользователя с информацией доступа к меню Курса'{id})'");
        var response = new APIResponse();
        try
        {
            if (id != Guid.Empty)
            {
                var item = await repository.GetByIdAsync(new IdentityDto(id));
                if (item is not null)
                {
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    var res = item.Adapt<UserWithMenuDto>();
                    response.Result = res; 
                    return Results.Ok(response);
                }
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }
}
