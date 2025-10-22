using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Repositories.Base;

public interface IKursReferencesBaseRepository<T>
{
    Task CreateAsync(Guid dbId, T entity);
    Task CreateManyAsync(Guid dbId, IEnumerable<T> entities);
    Task UpdateAsync(Guid dbId, T entity);
    Task UpdateManyAsync(Guid dbId, IEnumerable<T> entities);
    Task DeleteAsync(Guid dbId, IBaseIdentity id);
    Task DeleteManyAsync(Guid dbId, IEnumerable<IBaseIdentity> ids);
    Task<T?> GetByIdAsync(Guid dbId, IBaseIdentity id);
    Task<IEnumerable<T>> GetAllAsync(Guid dbId, CancellationToken cancelToken);
    string GetDbName(Guid id);
}
