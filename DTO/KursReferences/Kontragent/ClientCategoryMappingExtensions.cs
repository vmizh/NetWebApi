using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Kontragent;

public static class ClientCategoryMappingExtensions
{
    public static ClientCategoryDto MapToClientCategoryDto(this SD_148 entity)
    {
        return new ClientCategoryDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.CK_NAME,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_148 MapToSD_148(this ClientCategoryDto dto)
    {
        return new SD_148
        {
            DOC_CODE = dto.DocCode,
            CK_NAME = dto.Name,
            UpdateDate = dto.UpdateDate,
        };
    }
}
