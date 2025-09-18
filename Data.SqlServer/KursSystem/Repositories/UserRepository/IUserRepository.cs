using Data.SqlServer.KursSystem.Entities;

namespace Data.SqlServer.KursSystem.Repositories.UserRepository;

public interface IUserRepository
{
    Task<User?> GetByName(string name);
    Task<IEnumerable<KursMenuItem>?> GetRightsMenu(Guid userId, Guid dbId);
    Task<IEnumerable<KursMenuItem>?> GetFavoritesMenu(Guid userId, Guid dbId);
    Task<IEnumerable<KursMenuItem>?> GetOrderMenu(Guid userId);
    Task<IEnumerable<KursMenuGroup>?> GetOrderGroupMenu(Guid userId);
    Task<IEnumerable<KursMenuGroup>?> GetRightsGroupMenu(Guid userId, Guid dbId);

}
