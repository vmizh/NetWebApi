using System.Net;
using Common.Helper.API;
using Common.Repositories;
using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using Data.SqlServer.KursSystem.Repositories.UserRepository;
using DTO.Common;
using DTO.KursSystemDTO.KursMenu;
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

public class UserDtoService(
    IBaseRepository<User> repository,
    IUserRepository userRepository,
    IBaseRepository<KursMenuItem> menuRepository)
    : BaseDtoService<User, UserDto>(repository), IUserDtoService
{
    private readonly IBaseRepository<User> repository = repository;
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

    public async Task<IResult> GetByNameFullAsync(string name, Guid dbId)
    {
        Log.Logger.Information($"{RepositoryName}. Получение пользователя с правами на меню'{name})'");
        var response = new APIResponse();
        try
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var user = await userRepository.GetByName(name);
                if (user != null)
                {
                    var res = user.Adapt<UserWithMenuDto>();
                    foreach (var menu in (await userRepository.GetRightsMenu(res.Id, dbId))!)
                        res.RightsMenu.Add(menu.Adapt<KursMenuItemDto>());
                    foreach (var menu in (await userRepository.GetFavoritesMenu(res.Id, dbId))!)
                        res.FavoritesMenu.Add(menu.Adapt<KursMenuItemDto>());
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Result = res;
                    return Results.Ok(response);
                }

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.NoContent;
                return Results.NoContent();
            }
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }

        return Results.NoContent();
    }

    public async Task<IResult> GetFullByIdAsync(Guid userId, Guid dbId)
    {
        Log.Logger.Information(
            $"{RepositoryName}. Получение пользователя с информацией доступа к меню Курса'{userId})'");
        var response = new APIResponse();
        try
        {
            var user = await repository.GetByIdAsync(new IdentityDto(userId));
            if (user != null)
            {
                var res = user.Adapt<UserWithMenuDto>();
                foreach (var menu in (await userRepository.GetRightsMenu(res.Id, dbId))!)
                    res.RightsMenu.Add(menu.Adapt<KursMenuItemDto>());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = res;
                return Results.Ok(response);
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
