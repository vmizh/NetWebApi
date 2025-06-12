using Microsoft.AspNetCore.Http;
using Common.Helper.Interfaces.Identity;

namespace Common.Services;
public interface IBaseService<T> where T : class
{
    Task<IResult> CreateAsync(T item);
    Task<IResult> CreateManyAsync(IEnumerable<T> items);
    Task<IResult> UpdateAsync(T item);
    Task<IResult> UpdateManyAsync(IEnumerable<T> items);
    Task<IResult> DeleteAsync(IBaseIdentity id);
    Task<IResult> DeleteManyAsync(IEnumerable<IBaseIdentity> ids);
    Task<IResult> GetByIdAsync(IBaseIdentity id);
    Task<IResult> GetAllAsync();
}

public interface IBaseDtoService<T,D> 
    where T : class
    where D : class
{
    Task<IResult> CreateAsync(D item);
    Task<IResult> CreateManyAsync(IEnumerable<D> items);
    Task<IResult> UpdateAsync(D item);
    Task<IResult> UpdateManyAsync(IEnumerable<D> items);
    Task<IResult> DeleteAsync(IBaseIdentity id);
    Task<IResult> DeleteManyAsync(IEnumerable<IBaseIdentity> ids);
    Task<IResult> GetByIdAsync(IBaseIdentity id);
    Task<IResult> GetAllAsync();
}
