using Common.Services;
using Data.SqlServer.KursSystem.Entities;
using DTO.KursSystemDTO.KursMenu;
using Microsoft.AspNetCore.Http;

namespace Kurs.System.Services.Services.MenuServices;

public interface IMenuService
{
}

public interface IMenuDtoService : IBaseDtoService<KursMenuItem, KursMenuItemDto>
{
    public Task<IResult> CreateGroupMenu(KursMenuGroupDto item);
    public Task<IResult> UpdateGroupMenu(KursMenuGroupDto item);
    public Task<IResult> DeleteGroupMenu(int groupId);
    public Task<IResult> GetMenuGroup(int id);
    public Task<IResult> GetMenuGroups();
}
