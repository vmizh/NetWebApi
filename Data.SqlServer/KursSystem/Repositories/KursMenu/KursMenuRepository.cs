using Data.SqlServer.Base;
using Data.SqlServer.KursSystem.Context;
using Data.SqlServer.KursSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursSystem.Repositories.KursMenu;

public class KursMenuRepository(KursSystemContext dbCtx)
    : BaseRepository<KursMenuItem>(dbCtx), IKursMenuRepository
{
    private readonly KursSystemContext dbCtx = dbCtx;
    public async Task CreateGroupMenu(KursMenuGroup item)
    {
        var id = item.Id;
        if (id == 0)
            id = await dbCtx.KursMenuGroups.MaxAsync(_ => _.Id) + 1;
        item.Id = id;
        var sql = $@"SET IDENTITY_INSERT KursMenuGroup ON;
                    INSERT INTO dbo.KursMenuGroup
                    (
                      Id,
                      Name
                     ,Note
                     ,OrderBy
                     ,Picture
                     ,ParentId
                    )
                    VALUES
                    (
                      {item.Id}
                      ,'{item.Name}' 
                     ,'{item.Note}' 
                     ,{item.OrderBy} 
                     ,NULL 
                     ,NULL
                    );
                    SET IDENTITY_INSERT KursMenuGroup OFF;";
        await dbCtx.Database.ExecuteSqlRawAsync(sql);
    }

    public async Task UpdateGroupMenu(KursMenuGroup item)
    {
        dbCtx.KursMenuGroups.Update(item);
        await dbCtx.SaveChangesAsync();

    }

    public async Task DeleteGroupMenu(int groupId)
    {
        var old = await dbCtx.KursMenuGroups.FirstOrDefaultAsync(_ => _.Id == groupId);
        if (old != null)
        {
            dbCtx.KursMenuGroups.Remove(old);
            await dbCtx.SaveChangesAsync();
        }
    }


    public async Task<KursMenuGroup?> GetMenuGroup(int id)
    {
        return await dbCtx.KursMenuGroups.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<IEnumerable<KursMenuGroup>> GetMenuGroups()
    {
        return await dbCtx.KursMenuGroups.ToListAsync();
    }
}
