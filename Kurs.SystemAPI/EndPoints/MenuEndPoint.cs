using System.Net;
using Common.Helper.API;
using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;
using DTO.Common;
using DTO.KursSystemDTO.KursMenu;
using Kurs.System.Services.Services.MenuServices;
using Microsoft.AspNetCore.Mvc;
using Log = Serilog.Log;

namespace Kurs.SystemAPI.EndPoints;

public static class MenuEndPoint
{
    public static void ConfigureMenuEndPoints(this WebApplication app)
    {
        var menuMap = app.MapGroup("/api/menu");

        #region MenuItem

        menuMap.MapGet("/all", GetMenuItems).WithName("GetMenuItems");
        menuMap.MapGet("/{id:int}", GetMenuItem).WithName("GetMenuItem");

        menuMap.MapPost("/", AddMenuItem).WithName("AddMenuItem");
        menuMap.MapPut("/", UpdateMenuItem).WithName("UpdateMenuItem");
        menuMap.MapDelete("/{id:int}", DeleteMenuItem).WithName("DeleteMenuItem");

        #endregion

        #region MenuGroup

        menuMap.MapGet("/group/{id:int}", GetMenuGroupItem).WithName("GetMenuGroupItem");
        menuMap.MapGet("/group/all", GetMenuGroups).WithName("GetMenuGroups");

        menuMap.MapPost("/group", AddGroupMenu).WithName("AddGroupMenu");
        menuMap.MapPut("/group", UpdateGroupMenu).WithName("UpdateGroupMenu");
        menuMap.MapDelete("/group/{id:int}", DeleteGroupMenu).WithName("DeleteGroupMenu");

        #endregion
    }
    private static async Task<IResult> DeleteGroupMenu(int id, IMenuDtoService service)
    {
        Log.Logger.Information($"Удаление группы меню id='{id}'");
        return await service.DeleteGroupMenu(id);
    }

    private static async Task<IResult> UpdateGroupMenu([FromBody] KursMenuGroupDto item_dto, IMenuDtoService service)
    {
        Log.Logger.Information(
            $"Обновление группы меню: {item_dto.Name}('{((IBaseIdentity)item_dto).Id}' - {((IName)item_dto).Name}')");
        var response = new APIResponse();
        try
        {
            var saved = await service.UpdateGroupMenu(item_dto);
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = saved;
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    private static async Task<IResult> AddGroupMenu([FromBody] KursMenuGroupDto item_dto, IMenuDtoService service)
    {
        Log.Logger.Information($"Добавление группы меню системы Курс: {item_dto.Name}");
        var response = new APIResponse();
        try
        {
            var ret = await service.CreateGroupMenu(item_dto);

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = ret;
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    private static async Task<IResult> DeleteMenuItem(int id, IMenuDtoService service)
    {
        Log.Logger.Information($"Удаление пункта меню id='{id}'");
        return await service.DeleteAsync(new IdentityDto(id));
    }

    private static async Task<IResult> UpdateMenuItem([FromBody] KursMenuItemDto item_dto, IMenuDtoService service)
    {
        Log.Logger.Information(
            $"Обновление пункта меню: {item_dto.Name}('{((IBaseIdentity)item_dto).Id}' - {((IName)item_dto).Name}')");
        var response = new APIResponse();
        try
        {
            var saved = await service.UpdateAsync(item_dto);
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = saved;
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }


    private static async Task<IResult> AddMenuItem([FromBody] KursMenuItemDto item_dto, IMenuDtoService service)
    {
        Log.Logger.Information($"Добавление пункта меню системы Курс: {item_dto.Name}");
        var response = new APIResponse();
        try
        {
            var ret = await service.CreateAsync(item_dto);

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = ret;
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }


    private static async Task<IResult> GetMenuItems(IMenuDtoService service)
    {
        Log.Logger.Information("Получение всех пунктов меню системы Курс");
        return await service.GetAllAsync();
    }

    private static async Task<IResult> GetMenuItem(IMenuDtoService service, int id)
    {
        Log.Logger.Information($"Получение пункта меню системы Курс id ={id}");
        return await service.GetByIdAsync(new IdentityDto(id));
    }

    private static async Task<IResult> GetMenuGroupItem(IMenuDtoService service, int id)
    {
        Log.Logger.Information($"Получение пункта группы меню системы Курс id ={id}");
        return await service.GetMenuGroup(id);
    }

    private static async Task<IResult> GetMenuGroups(IMenuDtoService service)
    {
        Log.Logger.Information("Получение всех группп меню системы Курс");
        return await service.GetMenuGroups();
    }
}
