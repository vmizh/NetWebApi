using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Nomenkl;

public static class NomenklTypeMappingExtensions
{
    public static NomenklTypeDto MapToNomenklTypeDto(this SD_119 entity)
    {
        return new NomenklTypeDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.MC_NAME,
            UpdateDate = entity.UpdateDate,
            IsDeleted = entity.MC_DELETED == 1
        };
    }

    public static SD_119 MapToSD_119(this NomenklTypeDto dto)
    {
        return new SD_119
        {
            DOC_CODE = dto.DocCode,
            MC_NAME = dto.Name,
            MC_DELETED = (short)(dto.IsDeleted ? 1 : 0),
            UpdateDate = dto.UpdateDate
        };
    }
}
