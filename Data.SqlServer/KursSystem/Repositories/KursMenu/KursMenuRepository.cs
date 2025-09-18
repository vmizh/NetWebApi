using Data.SqlServer.Base;
using Data.SqlServer.KursSystem.Context;
using Data.SqlServer.KursSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursSystem.Repositories.KursMenu;

public class KursMenuRepository(KursSystemContext dbContext)
    : BaseRepository<KursMenuItem>(dbContext), IKursMenuRepository
{
    public async Task CreateGroupMenu(KursMenuGroup item)
    {
        var id = item.Id;
        if (id == 0)
            id = await dbContext.KursMenuGroups.MaxAsync(_ => _.Id) + 1;
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
        await dbContext.Database.ExecuteSqlRawAsync(sql);
        //await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT KursMenuGroup ON;");
        //await dbContext.KursMenuGroups.AddAsync(item);
        //await dbContext.SaveChangesAsync();
        //await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT KursMenuGroup OFF;");
    }

    public async Task UpdateGroupMenu(KursMenuGroup item)
    {
        dbContext.KursMenuGroups.Update(item);
        await dbContext.SaveChangesAsync();

    }

    public async Task DeleteGroupMenu(int groupId)
    {
        var old = await dbContext.KursMenuGroups.FirstOrDefaultAsync(_ => _.Id == groupId);
        if (old != null)
        {
            dbContext.KursMenuGroups.Remove(old);
            await dbContext.SaveChangesAsync();
        }
    }


    public async Task<KursMenuGroup?> GetMenuGroup(int id)
    {
        return await dbContext.KursMenuGroups.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<IEnumerable<KursMenuGroup>> GetMenuGroups()
    {
        return await dbContext.KursMenuGroups.ToListAsync();
    }
}
