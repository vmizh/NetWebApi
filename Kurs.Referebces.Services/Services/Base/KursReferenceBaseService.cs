using System.Net;
using Common.Helper.API;
using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;
using Data.SqlServer.KursReferences.Repositories.Base;
using Mapster;
using Serilog;

namespace Kurs.References.Services.Services.Base;

public class KursReferenceBaseService<T>(IKursReferencesBaseRepository<T> repository) : IKursReferencesBaseService<T>
    where T : class

{
    protected virtual string RepositoryName { set; get; } = "Базовый репозиторий";

    public virtual async Task<APIResponse> CreateAsync(APIRequest request)
    {
        var name = string.Empty;
        if (request.RequestData is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Создание сущности {name}({request.Id})");
        var response = new APIResponse
        {
            IsSuccess = false
        };
        try
        {
            var item = request.RequestData as T;
            if (item == null)
            {
                response.StatusCode = HttpStatusCode.NotImplemented;
                response.ErrorMessages.Add($"Item is not type {typeof(T)}");
                return response;
            }

            await repository.CreateAsync(request.DbId, item);
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = item;
            return response;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessages.Add(ex.Message);
            return response;
        }
    }

    public virtual async Task<APIResponse> CreateManyAsync(APIRequest request)
    {
        Log.Logger.Information($"{RepositoryName}. Создание сущностей из списка");
        var response = new APIResponse();
        try
        {
            var enumerable = request.RequestData as T[];
            if (enumerable == null)
            {
                response.StatusCode = HttpStatusCode.NotImplemented;
                response.ErrorMessages.Add($"Item is not type {typeof(T)}");
                return response;
            }

            if (enumerable.Any())
            {
                await repository.CreateManyAsync(request.DbId, enumerable.ToList());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return response;
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessages.Add(ex.Message);
            return response;
        }
    }

    public virtual async Task<APIResponse> UpdateAsync(APIRequest request)
    {
        var name = string.Empty;
        if (request.RequestData is IName n)
            name = n.Name;
        Log.Logger.Information($"{RepositoryName}. Обновление сущности {name}({request.Id})");
        var response = new APIResponse();
        try
        {
            var item = request.RequestData as T;
            if (item == null)
            {
                response.StatusCode = HttpStatusCode.NotImplemented;
                response.ErrorMessages.Add($"Item is not type {typeof(T)}");
                return response;
            }

            if (!Guid.Empty.Equals(((IBaseIdentity)item).Id))
            {
                await repository.UpdateAsync(request.DbId, item.Adapt<T>());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return response;
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessages.Add(ex.Message);
            return response;
        }
    }

    public virtual async Task<APIResponse> UpdateManyAsync(APIRequest request)
    {
        Log.Logger.Information($"{RepositoryName}. Обновление сущностей из списка");
        var response = new APIResponse();
        try
        {
            var enumerable = request.RequestData as T[];
            if (enumerable == null)
            {
                response.StatusCode = HttpStatusCode.NotImplemented;
                response.ErrorMessages.Add($"Item is not type {typeof(T)}");
                return response;
            }

            if (enumerable.Any())
            {
                await repository.UpdateManyAsync(request.DbId, enumerable.ToList());
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return response;
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessages.Add(ex.Message);
            return response;
        }
    }

    public virtual async Task<APIResponse> DeleteAsync(APIRequest request)
    {
        Log.Logger.Information($"{RepositoryName}. Удаление сущности с id='{request.Id})'");
        var response = new APIResponse
        {
            IsSuccess = false
        };
        try
        {
            switch (request.Id)
            {
                case Guid gId:
                    if (Guid.Empty.Equals(gId))
                    {
                        response.ErrorMessages.Add("Неправильный ключ");
                        return response;
                    }
                    break;
                case int iId:
                    if (iId <= 0)
                    {
                        response.ErrorMessages.Add("Неправильный ключ");
                        return response;
                    }
                    break;
                case decimal dId:
                    if (dId <= 0)
                    {
                        response.ErrorMessages.Add("Неправильный ключ");
                        return response;
                    }
                    break;
                default:
                    response.ErrorMessages.Add("Неправильный ключ");
                    return response;
            }
            await repository.DeleteAsync(request.DbId, (IBaseIdentity)request.Id);
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = true;
            return response;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessages.Add(ex.Message);
            return response;
        }
    }

    public virtual async Task<APIResponse>
        DeleteManyAsync(APIRequest request) //Guid dbId, IEnumerable<IBaseIdentity> ids)
    {
        Log.Logger.Information($"{RepositoryName}. Удаление сущностей из списка");
        var response = new APIResponse();
        try
        {
            var baseIdentities = request.RequestData as IBaseIdentity[];
            if (baseIdentities == null)
            {
                response.StatusCode = HttpStatusCode.NotImplemented;
                response.ErrorMessages.Add($"Item is not type {typeof(T)}");
                return response;
            }

            if (baseIdentities.Any())
            {
                await repository.DeleteManyAsync(request.DbId, baseIdentities.ToList());

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = true;
                return response;
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessages.Add(ex.Message);
            return response;
        }
    }

    public virtual async Task<APIResponse> GetByIdAsync(APIRequest request) //Guid dbId, IBaseIdentity id)
    {
        Log.Logger.Information($"{RepositoryName}. Получение сущности с id='{request.DbId})'");
        var response = new APIResponse();
        try
        {
            switch (request.Id)
            {
                case Guid gId:
                    if (Guid.Empty.Equals(gId))
                    {
                        response.ErrorMessages.Add("Неправильный ключ");
                        return response;
                    }

                    break;
                case int iId:
                    if (iId <= 0)
                    {
                        response.ErrorMessages.Add("Неправильный ключ");
                        return response;
                    }

                    break;
                case decimal dId:
                    if (dId <= 0)
                    {
                        response.ErrorMessages.Add("Неправильный ключ");
                        return response;
                    }

                    break;
                default:
                    response.ErrorMessages.Add("Неправильный ключ");
                    return response;
            }

            var item = await repository.GetByIdAsync(request.DbId, (IBaseIdentity)request.Id);
            if (item is not null)
            {
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = item;
                return response;
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessages.Add(ex.Message);
            return response;
        }
    }

    public virtual async Task<APIResponse> GetAllAsync(APIRequest request, CancellationToken cancelToken)
    {
        Log.Logger.Information($"{RepositoryName}. Получение всех записей.");
        var response = new APIResponse();
        try
        {
            var data = await repository.GetAllAsync(request.DbId, cancelToken);
            if (!data.Any())
            {
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.NoContent;
                return response;
            }

            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Result = data;
            return response;
        }
        catch (Exception ex)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ErrorMessages.Add(ex.Message);
            return response;
        }
    }
}
