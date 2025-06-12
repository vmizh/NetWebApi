using System.Net;
using Common.Helper.API;
using Common.Repositories;
using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using Data.SqlServer.KursSystem.Repositories.UserRepository;
using DTO.KursSystemDTO;
using Mapster;
using Microsoft.AspNetCore.Http;
using Log = Serilog.Log;

namespace Kurs.System.Services.Services.UserService;

public class UserService(IBaseRepository<User> repository, IUserRepository dsRepository)
    : BaseService<User>(repository), IUserService
{
    private IUserRepository UserRepository = dsRepository;
    protected override string RepositoryName => "Репозиторий пользователей Курса";
}

public class UserDtoService(IBaseRepository<User> repository, IUserRepository dsRepository)
    : BaseDtoService<User, UserDto>(repository), IUserDtoService
{
    private IUserRepository UserRepository = dsRepository;
    protected override string RepositoryName => "Репозиторий пользователей Курса";

    public async Task<IResult> GetByNameAsync(string name)
    {
        Log.Logger.Information($"{RepositoryName}. Получение пользователя'{name})'");
        var response = new APIResponse();
        try
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var item = await dsRepository.GetByName(name);
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
}
