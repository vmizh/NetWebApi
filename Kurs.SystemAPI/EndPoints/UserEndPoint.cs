using Common.Helper.API;
using DTO.Common;
using Kurs.System.Services.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;
using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;
using DTO.KursSystemDTO.User;

namespace Kurs.SystemAPI.EndPoints;

public static class UserEndPoint
{
    public static void ConfigureUserEndPoints(this WebApplication app)
    {
        var userMap = app.MapGroup("/api/user");
        userMap.MapGet("/entity/all", GetUsers).WithName("GetUsers");
        userMap.MapGet("/all", GetUsersDto).WithName("GetUsersDto");
        userMap.MapGet("/{id:guid}", GetUser).WithName("GetUser");
        userMap.MapGet("/user-name/{name:alpha}", GetUserByName).WithName("GetUserByName");
        userMap.MapPost("/", AddUser).WithName("AddUser");
        userMap.MapPut("/", UpdateUser).WithName("UpdateUser");
        userMap.MapDelete("/{id:guid}", DeleteUser).WithName("DeleteUser");
    }

    private static async Task<IResult> DeleteUser(Guid id, IUserDtoService service)
    {
        Log.Logger.Information($"Удаление пользователя id='{id}'");
        return await service.DeleteAsync(new IdentityDto(id));
    }

    private static async Task<IResult> UpdateUser([FromBody] UserDto item_dto,
        IUserDtoService service)
    {
        Log.Logger.Information($"Обновление пользователя: {item_dto.Name}('{((IBaseIdentity)item_dto).Id}' - {((IName)item_dto).Name}')");
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

    private static async Task<IResult> AddUser([FromBody] UserDto user_dto, IUserDtoService service)
    {
        Log.Logger.Information($"Добавление пользователя: {user_dto.Name}");
        var response = new APIResponse();
        try
        {
            var ret = await service.CreateAsync(user_dto);

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

    private static async Task<IResult> GetUserByName(IUserDtoService service, string name)
    {
        Log.Logger.Information($"Получение пользователя по имени '{name}'");
        return await service.GetByNameAsync(name);
    }

    private static async Task<IResult>  GetUser(IUserDtoService service, Guid id)
    {
        Log.Logger.Information($"Получение пользователя '{id}'");
        return await service.GetByIdAsync(new IdentityDto(id));
    }

    private static async Task<IResult> GetUsers(IUserService service)
    {
        Log.Logger.Information("Получение списка пользовтелей, зарегистрированных в курсе");
        return await service.GetAllAsync();
    }
    private static async Task<IResult> GetUsersDto(IUserDtoService service)
    {
        Log.Logger.Information("Получение списка пользователей, зарегистрированных в курсе");
        return await service.GetAllAsync();
    }
}
