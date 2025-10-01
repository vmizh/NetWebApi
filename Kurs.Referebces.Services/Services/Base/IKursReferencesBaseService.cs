using Common.Helper.API;

namespace Kurs.References.Services.Services.Base;

public interface IKursReferencesBaseService<T> where T : class
{
    Task<APIResponse> CreateAsync(APIRequest request);
    Task<APIResponse> CreateManyAsync(APIRequest request);
    Task<APIResponse> UpdateAsync(APIRequest request);
    Task<APIResponse> UpdateManyAsync(APIRequest request);
    Task<APIResponse> DeleteAsync(APIRequest request);
    Task<APIResponse> DeleteManyAsync(APIRequest request);
    Task<APIResponse> GetByIdAsync(APIRequest requestd);
    Task<APIResponse> GetAllAsync(APIRequest request, CancellationToken cancelToken);
}
