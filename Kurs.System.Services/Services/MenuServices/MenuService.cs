using Common.Helper.API;
using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;
using Common.Repositories;
using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using Data.SqlServer.KursSystem.Repositories.KursMenu;
using DTO.KursSystemDTO.KursMenu;
using Mapster;
using Microsoft.AspNetCore.Http;
using System.Net;
using Log = Serilog.Log;

namespace Kurs.System.Services.Services.MenuServices;

public class MenuService(IBaseRepository<KursMenuItem> repository, IKursMenuRepository menuRepository)
    : BaseService<KursMenuItem>(repository), IMenuService
{
    protected override string RepositoryName => "Репозиторий системного меню Курс";
}

public class MenuDtoService(IBaseRepository<KursMenuItem> repository, IKursMenuRepository menuRepository)
    : BaseDtoService<KursMenuItem, KursMenuItemDto>(repository), IMenuDtoService
{
    protected override string RepositoryName => "Репозиторий системного меню Курс";

    public async Task<IResult> CreateGroupMenu(KursMenuGroupDto item)
    {
        var name = string.Empty;
        if (item is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Создание группы меню системы курс {name}({((IBaseIdentity)item).Id})");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(((IBaseIdentity)item).Id))
            {
                await menuRepository.CreateGroupMenu(item.Adapt<KursMenuGroup>());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = item;
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

    public async Task<IResult> UpdateGroupMenu(KursMenuGroupDto item)
    {
        var name = string.Empty;
        if (item is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Обновление группы мению {name}({((IBaseIdentity)item).Id})");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(((IBaseIdentity)item).Id))
            {
                await menuRepository.UpdateGroupMenu(item.Adapt<KursMenuGroup>());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
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

    public async Task<IResult> DeleteGroupMenu(int groupId)
    {
        Log.Logger.Information($"{RepositoryName}. Удаление группы меню системы Курс с id='{groupId})'");
        var response = new APIResponse
        {
            IsSuccess = false
        };
        try
        {
            if (groupId != 0)
            {
                await menuRepository.DeleteGroupMenu(groupId);

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
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

    public async Task<IResult> GetMenuGroup(int id)
    {
        Log.Logger.Information($"{RepositoryName}. Получение пункта группы меню Курса'{id}'");
        var response = new APIResponse();
        try
        {
            if (id != 0)
            {
                var item = await menuRepository.GetMenuGroup(id);
                if (item is not null)
                {
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    var res = item.Adapt<KursMenuGroupDto>();
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

    public async Task<IResult> GetMenuGroups()
    {
        Log.Logger.Information($"{RepositoryName}. Получение всех групп меню Курса");
        var response = new APIResponse();
        try
        {
            var items = await menuRepository.GetMenuGroups();
            var res = items.Select(item => item.Adapt<KursMenuGroupDto>()).ToList();
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = res;
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }
}
