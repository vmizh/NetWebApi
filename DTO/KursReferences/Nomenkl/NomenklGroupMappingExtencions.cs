using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Nomenkl;

public static class NomenklGroupMappingExtencions
{
    public static NomenklGroupDto MapToNomenklGroupDto(this SD_82 entity)
    {
        return new NomenklGroupDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.CAT_NAME,
            ParentDC = entity.CAT_PARENT_DC,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_82 MapToSD_82(this NomenklGroupDto dto)
    {
        return new SD_82
        {
            DOC_CODE = dto.DocCode,
            CAT_PARENT_DC = dto.ParentDC,
            CAT_NAME = dto.Name,
            UpdateDate = dto.UpdateDate
        };
    }
}
