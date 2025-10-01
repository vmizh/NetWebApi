using Common.Helper.Interfaces.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Common.Repositories;

public interface IBaseRepository<T>
{
    Task CreateAsync(T entity);
    Task CreateManyAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateManyAsync(IEnumerable<T> entities);
    Task DeleteAsync(IBaseIdentity id);
    Task DeleteManyAsync(IEnumerable<IBaseIdentity> ids);
    Task<T?> GetByIdAsync(IBaseIdentity id);
    Task<IEnumerable<T>> GetAllAsync();
}


public interface IBaseDbRepository<T> : IBaseRepository<T>
{
    void SetDbContext(string name);
    void SetDbContext(Guid id);
    string GetDbName(Guid id);
}

