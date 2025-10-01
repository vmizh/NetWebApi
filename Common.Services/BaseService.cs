using System.Net;
using Common.Helper.API;
using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;
using Common.Repositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Common.Services;

public class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T>
    where T : class

{
    protected virtual string RepositoryName { set; get; } = "Базовый репозиторий";

    public virtual async Task<IResult> CreateAsync(T item)
    {
        var name = string.Empty;
        if (item is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Создание сущности {name}({((IBaseIdentity)item).Id})");
        var response = new APIResponse();
        try
        {
            await repository.CreateAsync(item);
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = item;
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> CreateManyAsync(IEnumerable<T> items)
    {
        Log.Logger.Information($"{RepositoryName}. Создание сущностей из списка");
        var response = new APIResponse();
        try
        {
            var enumerable = items as T[] ?? items.ToArray();
            if (enumerable.Any())
            {
                await repository.CreateManyAsync(enumerable.ToList());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> UpdateAsync(T item)
    {
        var name = string.Empty;
        if (item is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Обновление сущности {name}({((IBaseIdentity)item).Id})");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(((IBaseIdentity)item).Id))
            {
                await repository.UpdateAsync(item.Adapt<T>());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> UpdateManyAsync(IEnumerable<T> items)
    {
        Log.Logger.Information($"{RepositoryName}. Обновление сущностей из списка");
        var response = new APIResponse();
        try
        {
            var enumerable = items as T[] ?? items.ToArray();
            if (enumerable.Any())
            {
                await repository.UpdateManyAsync(enumerable.ToList());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> DeleteAsync(IBaseIdentity id)
    {
        Log.Logger.Information($"{RepositoryName}. Удаление сущности с id='{id})'");
        var response = new APIResponse
        {
            IsSuccess = false
        };
        try
        {
            if (!Guid.Empty.Equals(id))
            {
                await repository.DeleteAsync(id);

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> DeleteManyAsync(IEnumerable<IBaseIdentity> ids)
    {
        Log.Logger.Information($"{RepositoryName}. Удаление сущностей из списка");
        var response = new APIResponse();
        try
        {
            var baseIdentities = ids as IBaseIdentity[] ?? ids.ToArray();
            if (baseIdentities.Any())
            {
                await repository.DeleteManyAsync(baseIdentities.ToList());

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> GetByIdAsync(IBaseIdentity id)
    {
        Log.Logger.Information($"{RepositoryName}. Получение сущности с id='{id})'");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(id))
            {
                var item = await repository.GetByIdAsync(id);
                if (item is not null)
                {
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Result = item;
                    return Results.Ok(response);
                }
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> GetAllAsync()
    {
        Log.Logger.Information($"{RepositoryName}. Получение всех записей");
        var response = new APIResponse();
        try
        {
            var data = await repository.GetAllAsync();
            if (!data.Any())
            {
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.NoContent;
                return Results.NoContent();
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = data;
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }
}

public class BaseDtoService<T, D>(IBaseRepository<T> repository) : IBaseDtoService<T, D>
    where T : class
    where D : class

{
    protected virtual string RepositoryName { set; get; } = "Базовый репозиторий";

    public virtual async Task<IResult> CreateAsync(D item)
    {
        var name = string.Empty;
        if (item is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Создание сущности {name}({((IBaseIdentity)item).Id})");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(((IBaseIdentity)item).Id))
            {
                await repository.CreateAsync(item.Adapt<T>());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = item;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> CreateManyAsync(IEnumerable<D> items)
    {
        Log.Logger.Information($"{RepositoryName}. Создание сущностей из списка");
        var response = new APIResponse();
        try
        {
            var enumerable = items as D[] ?? items.ToArray();
            if (enumerable.Any())
            {
                await repository.CreateManyAsync(enumerable.Select(t => t.Adapt<T>()).ToList());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> UpdateAsync(D item)
    {
        var name = string.Empty;
        if (item is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Обновление сущности {name}({((IBaseIdentity)item).Id})");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(((IBaseIdentity)item).Id))
            {
                await repository.UpdateAsync(item.Adapt<T>());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> UpdateManyAsync(IEnumerable<D> items)
    {
        Log.Logger.Information($"{RepositoryName}. Обновление сущностей из списка");
        var response = new APIResponse();
        try
        {
            var enumerable = items as D[] ?? items.ToArray();
            if (enumerable.Any())
            {
                await repository.UpdateManyAsync(enumerable.Select(t => t.Adapt<T>()).ToList());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> DeleteAsync(IBaseIdentity id)
    {
        Log.Logger.Information($"{RepositoryName}. Удаление сущности с id='{id})'");
        var response = new APIResponse
        {
            IsSuccess = false
        };
        try
        {
            if (!Guid.Empty.Equals(id))
            {
                await repository.DeleteAsync(id);

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> DeleteManyAsync(IEnumerable<IBaseIdentity> ids)
    {
        Log.Logger.Information($"{RepositoryName}. Удаление сущностей из списка");
        var response = new APIResponse();
        try
        {
            var baseIdentities = ids as IBaseIdentity[] ?? ids.ToArray();
            if (baseIdentities.Any())
            {
                await repository.DeleteManyAsync(baseIdentities.ToList());

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> GetByIdAsync(IBaseIdentity id)
    {
        Log.Logger.Information($"{RepositoryName}. Получение сущности с id='{id})'");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(id))
            {
                var item = await repository.GetByIdAsync(id);
                if (item is not null)
                {
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Result = item.Adapt<D>();
                    return Results.Ok(response);
                }
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> GetAllAsync()
    {
        Log.Logger.Information($"{RepositoryName}. Получение всех записей");
        var response = new APIResponse();
        try
        {
            var data = await repository.GetAllAsync();
            var enumerable = data as T[] ?? data.ToArray();
            if (!enumerable.Any())
            {
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.NoContent;
                return Results.NoContent();
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = enumerable.Select(item => item.Adapt<D>()).ToList();
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

}

public class BaseDbDtoService<T, D>(IBaseDbRepository<T> repository) : IBaseDbDtoService<T, D>
    where T : class
    where D : class

{
    protected virtual string RepositoryName { set; get; } = "Базовый репозиторий";

    public virtual async Task<IResult> CreateAsync(D item, Guid dbId)
    {
        var name = string.Empty;
        if (item is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Создание сущности {name}({((IBaseIdentity)item).Id}). БД:{repository.GetDbName(dbId)}");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(((IBaseIdentity)item).Id))
            {
                repository.SetDbContext(dbId);
                await repository.CreateAsync(item.Adapt<T>());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = item;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> CreateManyAsync(IEnumerable<D> items, Guid dbId)
    {
        Log.Logger.Information($"{RepositoryName}. Создание сущностей из списка. БД:{repository.GetDbName(dbId)}");
        var response = new APIResponse();
        try
        {
            var enumerable = items as D[] ?? items.ToArray();
            if (enumerable.Any())
            {
                repository.SetDbContext(dbId);
                await repository.CreateManyAsync(enumerable.Select(t => t.Adapt<T>()).ToList());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> UpdateAsync(D item, Guid dbId)
    {
        var name = string.Empty;
        if (item is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Обновление сущности {name}({((IBaseIdentity)item).Id}). БД:{repository.GetDbName(dbId)}");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(((IBaseIdentity)item).Id))
            {
                repository.SetDbContext(dbId);
                await repository.UpdateAsync(item.Adapt<T>());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> UpdateManyAsync(IEnumerable<D> items, Guid dbId)
    {
        Log.Logger.Information($"{RepositoryName}. Обновление сущностей из списка. БД:{repository.GetDbName(dbId)}");
        var response = new APIResponse();
        try
        {
            var enumerable = items as D[] ?? items.ToArray();
            if (enumerable.Any())
            {
                repository.SetDbContext(dbId);
                await repository.UpdateManyAsync(enumerable.Select(t => t.Adapt<T>()).ToList());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> DeleteAsync(IBaseIdentity id, Guid dbId)
    {
        Log.Logger.Information($"{RepositoryName}. Удаление сущности с id='{id})'. БД:{repository.GetDbName(dbId)}");
        var response = new APIResponse
        {
            IsSuccess = false
        };
        try
        {
            if (!Guid.Empty.Equals(id))
            {
                repository.SetDbContext(dbId);
                await repository.DeleteAsync(id);

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> DeleteManyAsync(IEnumerable<IBaseIdentity> ids, Guid dbId)
    {
        Log.Logger.Information($"{RepositoryName}. Удаление сущностей из списка. БД:{repository.GetDbName(dbId)}");
        var response = new APIResponse();
        try
        {
            var baseIdentities = ids as IBaseIdentity[] ?? ids.ToArray();
            if (baseIdentities.Any())
            {
                repository.SetDbContext(dbId);
                await repository.DeleteManyAsync(baseIdentities.ToList());

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return Results.Ok(response);
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

    public virtual async Task<IResult> GetByIdAsync(IBaseIdentity id, Guid dbId)
    {
        Log.Logger.Information($"{RepositoryName}. Получение сущности с id='{id})'. БД:{repository.GetDbName(dbId)}");
        var response = new APIResponse();
        try
        {
            if (!Guid.Empty.Equals(id))
            {
                repository.SetDbContext(dbId);
                var item = await repository.GetByIdAsync(id);
                if (item is not null)
                {
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Result = item.Adapt<D>();
                    return Results.Ok(response);
                }
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }
    
    public virtual async Task<IResult> GetAllAsync(Guid dbId)
    {
        Log.Logger.Information($"{RepositoryName}. Получение всех записей. БД:{repository.GetDbName(dbId)}");
        var response = new APIResponse();
        try
        {
            repository.SetDbContext(dbId);
            var data = await repository.GetAllAsync();
            var enumerable = data as T[] ?? data.ToArray();
            if (!enumerable.Any())
            {
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.NoContent;
                return Results.NoContent();
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = enumerable.Select(item => item.Adapt<D>()).ToList();
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return APIResponse.ReturnError(response, ex, Log.Logger);
        }
    }

}


