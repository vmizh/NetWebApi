using Data.SqlServer.KursSystem.Entities;

namespace Data.SqlServer.KursSystem.Repositories.KursMenu;

public interface IKursMenuRepository
{
    public Task CreateGroupMenu(KursMenuGroup item);
    public Task UpdateGroupMenu(KursMenuGroup item);
    public Task DeleteGroupMenu(int groupId);
    public Task<KursMenuGroup?> GetMenuGroup(int id);
    public Task<IEnumerable<KursMenuGroup>> GetMenuGroups();
}
