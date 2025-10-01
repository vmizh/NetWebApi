using Data.SqlServer.Base;
using Data.SqlServer.KursSystem.Context;
using Data.SqlServer.KursSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursSystem.Repositories.UserRepository;

public class UserRepository(KursSystemContext myDbContext)
    : BaseRepository<User>(myDbContext: myDbContext), IUserRepository
{
    private readonly KursSystemContext myDbContext = myDbContext;

    public async Task<User?> GetByName(string name)
    {
        return await myDbContext.Set<User>().FirstOrDefaultAsync(_ => _.Name == name);
    }

    public async Task<IEnumerable<KursMenuItem>?>  GetRightsMenu(Guid userId, Guid dbId)
    {
        var user = await myDbContext.Users.FirstOrDefaultAsync(_ => _.Id == userId);
        if (user == null) return null;
        return await myDbContext.UserMenuRights.Include(_ => _.Menu)
            .Where(_ => _.LoginName == user.Name && _.DBId == dbId).Select(_ => _.Menu).ToListAsync();
    }

    public async Task<IEnumerable<KursMenuItem>?> GetFavoritesMenu(Guid userId, Guid dbId)
    {
        return await myDbContext.UserMenuFavorites.Include(_ => _.Menu).Where(_ => _.UserId == userId && _.DbId == dbId)
            .Select(_ => _.Menu).ToListAsync();
    }

    public async Task<IEnumerable<KursMenuItem>?> GetOrderMenu(Guid userId)
    {
        var res = new List<KursMenuItem>();
        foreach (var item in await myDbContext.UserMenuOrders.Where(_ => _.UserId == userId && _.IsGroup == false).ToListAsync())
        {
            var menu = await myDbContext.KursMenuItems.FirstOrDefaultAsync(_ => _.Id == item.TileId);
            if (menu == null) continue;
            res.Add(menu);
        }

        return res;
    }
    public async Task<IEnumerable<KursMenuGroup>?> GetOrderGroupMenu(Guid userId)
    {
        var res = new List<KursMenuGroup>();
        foreach (var item in await myDbContext.UserMenuOrders.Where(_ => _.UserId == userId && _.IsGroup == true).ToListAsync())
        {
            var menu = await myDbContext.KursMenuGroups.FirstOrDefaultAsync(_ => _.Id == item.TileId);
            if (menu == null) continue;
            res.Add(menu);
        }

        return res;
    }

    public async Task<IEnumerable<KursMenuGroup>?> GetRightsGroupMenu(Guid userId, Guid dbId)
    {
        var user = await myDbContext.Users.FirstOrDefaultAsync(_ => _.Id == userId);
        if (user == null) return null;
        var menus = await myDbContext.UserMenuRights.Include(_ => _.Menu)
            .Where(_ => _.LoginName == user.Name && _.DBId == dbId).Select(_ => _.Menu).ToListAsync();
        var res = new List<KursMenuGroup>();
        foreach (var menu in menus)
        {
            var grp = await myDbContext.KursMenuGroups.FirstOrDefaultAsync(_ => _.Id == menu.GroupId);
            if (grp == null) continue;
            res.Add(grp);
        }

        return res;
    }
}
