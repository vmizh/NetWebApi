using Common.Helper.API;

namespace Kurs.References.Services.Services.Base;

public interface IKursReferencesBaseService<T> where T : class
{
    Task<APIResponse> CreateAsync(APIRequest request, CancellationToken cancelToken);
    Task<APIResponse> CreateManyAsync(APIRequest request, CancellationToken cancelToken);
    Task<APIResponse> UpdateAsync(APIRequest request, CancellationToken cancelToken);
    Task<APIResponse> UpdateManyAsync(APIRequest request, CancellationToken cancelToken);
    Task<APIResponse> DeleteAsync(APIRequest request, CancellationToken cancelToken);
    Task<APIResponse> DeleteManyAsync(APIRequest request, CancellationToken cancelToken);
    Task<APIResponse> GetByIdAsync(APIRequest requestd, CancellationToken cancelToken);
    Task<APIResponse> GetAllAsync(APIRequest request, CancellationToken cancelToken);
    Task<APIResponse> GetListAsync(APIRequest request, CancellationToken cancelToken);
    Task<APIResponse> FindAsync(APIRequest request, CancellationToken cancelToken);
}

