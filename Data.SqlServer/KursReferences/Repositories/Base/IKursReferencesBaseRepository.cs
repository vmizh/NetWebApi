using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursReferences.Repositories.Base;

public interface IKursReferencesBaseRepository<T>
{
    Task CreateAsync(Guid dbId, T entity, CancellationToken cancelToken);
    Task CreateManyAsync(Guid dbId, IEnumerable<T> entities, CancellationToken cancelToken);
    Task UpdateAsync(Guid dbId, T entity, CancellationToken cancelToken);
    Task UpdateManyAsync(Guid dbId, IEnumerable<T> entities, CancellationToken cancelToken);
    Task DeleteAsync(Guid dbId, IBaseIdentity id, CancellationToken cancelToken);
    Task DeleteManyAsync(Guid dbId, IEnumerable<IBaseIdentity> ids, CancellationToken cancelToken);
    Task<T?> GetByIdAsync(Guid dbId, IBaseIdentity id, CancellationToken cancelToken);
    Task<IEnumerable<T>> GetAllAsync(Guid dbId, CancellationToken cancelToken);
    Task<IEnumerable<T>> GetListAsync(Guid dbId, List<IBaseIdentity> ids, CancellationToken cancelToken);
    string GetDbName(Guid id);
}
