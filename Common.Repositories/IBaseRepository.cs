using Common.Helper.Interfaces.Identity;
using Common.Repositories.Specification;

namespace Common.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task CreateManyAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateManyAsync(IEnumerable<T> entities);
    Task DeleteAsync(IBaseIdentity id);
    Task DeleteManyAsync(IEnumerable<IBaseIdentity> ids);
    Task<T?> GetByIdAsync(IBaseIdentity id);
    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> WhereAsync(
        ISpecification<T> specification,
        CancellationToken cancellationToken = default);
}

public interface IBaseDbRepository<T> : IBaseRepository<T> where T : class
{
    void SetDbContext(string name);
    void SetDbContext(Guid id);
    string GetDbName(Guid id);
}
