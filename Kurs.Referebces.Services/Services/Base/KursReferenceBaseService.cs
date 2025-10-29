using System.Net;
using Common.Helper.API;
using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;
using Data.SqlServer.KursReferences.Repositories.Base;
using DTO.Common;
using Mapster;
using Newtonsoft.Json;
using Serilog;

namespace Kurs.References.Services.Services.Base;

public class KursReferenceBaseService<T>(IKursReferencesBaseRepository<T> repository) : IKursReferencesBaseService<T>
    where T : class

{
    protected virtual string RepositoryName { set; get; } = "Базовый репозиторий";

    public virtual async Task<APIResponse> CreateAsync(APIRequest request, CancellationToken cancelToken)
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

            await repository.CreateAsync(request.DbId, item, cancelToken);
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

    public virtual async Task<APIResponse> CreateManyAsync(APIRequest request, CancellationToken cancelToken)
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
                await repository.CreateManyAsync(request.DbId, enumerable.ToList(),cancelToken);
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

    public virtual async Task<APIResponse> UpdateAsync(APIRequest request, CancellationToken cancelToken)
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
                await repository.UpdateAsync(request.DbId, item.Adapt<T>(), cancelToken);
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

    public virtual async Task<APIResponse> UpdateManyAsync(APIRequest request, CancellationToken cancelToken)
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
                await repository.UpdateManyAsync(request.DbId, enumerable.ToList(), cancelToken);
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

    public virtual async Task<APIResponse> DeleteAsync(APIRequest request, CancellationToken cancelToken)
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
            await repository.DeleteAsync(request.DbId, (IBaseIdentity)request.Id, cancelToken);
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
        DeleteManyAsync(APIRequest request, CancellationToken cancelToken) //Guid dbId, IEnumerable<IBaseIdentity> ids)
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
                await repository.DeleteManyAsync(request.DbId, baseIdentities.ToList(), cancelToken);

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

    public virtual async Task<APIResponse> GetByIdAsync(APIRequest request, CancellationToken cancelToken) //Guid dbId, IBaseIdentity id)
    {
        Log.Logger.Information($"{RepositoryName}. Получение сущности с базой id='{request.DbId})'");
        var response = new APIResponse();
        try
        {
            int iId = 0;
            Guid.TryParse(request.Id.ToString(), out var gId);
            decimal.TryParse(request.Id.ToString(), out var dId);
            if (dId < 1000000000)
                iId = Convert.ToInt32(dId);
            if (gId == Guid.Empty && dId == 0 && iId == 0)
            {
                response.ErrorMessages.Add("Неправильный ключ");
                return response;
            }
            T? item = null;
            if(gId != Guid.Empty)
                item = await repository.GetByIdAsync(request.DbId, new IdentityDto(gId), cancelToken);
            if(dId != 0)
                item = await repository.GetByIdAsync(request.DbId, new IdentityDto(dId), cancelToken);
            if(iId != 0)
                item = await repository.GetByIdAsync(request.DbId, new IdentityDto(iId), cancelToken);
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

    public virtual async Task<APIResponse>  GetListAsync(APIRequest request, CancellationToken cancelToken)
    {
        Log.Logger.Information($"{RepositoryName}. Получение список записей по ключам.");
        var response = new APIResponse();
        try
        {
            var lst = JsonConvert.DeserializeObject<List<object>>(request.Id.ToString());
            if (lst is null || lst.Count == 0)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ErrorMessages.Add("Не переданы ключи для выбора списка");
                return response;
            }
            var id_list = lst.Select(id => new IdentityDto(id)).Cast<IBaseIdentity>().ToList();
            var data = await repository.GetListAsync(request.DbId, id_list, cancelToken);
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
