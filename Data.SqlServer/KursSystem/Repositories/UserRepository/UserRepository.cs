using Data.SqlServer.KursSystem.Context;
using Data.SqlServer.KursSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursSystem.Repositories.UserRepository;

public class UserRepository(KursSystemContext dbContext)
    : BaseRepository<User>(dbContext), IUserRepository
{
    public async Task<User?> GetByName(string name)
    {
        return await dbContext.Set<User>().FirstOrDefaultAsync(_ => _.Name == name);
    }

    public async Task<IEnumerable<UserMenuRight>?>  GetRightsMenu(Guid userId, Guid dbId)
    {
        var user = await dbContext.Set<User>().FirstOrDefaultAsync(_ => _.Id == userId);
        if (user == null) return null;
        return await dbContext.Set<UserMenuRight>().Where(_ => _.LoginName == user.Name && _.DBId == dbId).ToListAsync();
    }
}
