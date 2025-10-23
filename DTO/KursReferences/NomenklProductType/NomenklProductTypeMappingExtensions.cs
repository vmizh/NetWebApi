using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.NomenklProductType;

public static class NomenklProductTypeMappingExtensions
{
    public static NomenklProductTypeDto MapToNomenklProductTypeDto(this SD_77 entity)
    {
        return new NomenklProductTypeDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.TV_NAME,
            UpdateDate = entity.UpdateDate,
            Id = entity.Id
        };
    }

    public static NomenklProductTypeFullDto MapToNomenklProductTypeFullDto(this SD_77 entity)
    {
        return new NomenklProductTypeFullDto
        {
            Id = entity.Id,
            DocCode = entity.DOC_CODE,
            Name = entity.TV_NAME,
            UpdateDate = entity.UpdateDate,
            ShpzDC = entity.TV_SHPZ_DC,
            Type = entity.TV_TYPE
        };
    }

    public static SD_77 MapToSD_77(this NomenklProductTypeDto dto)
    {
        return new SD_77
        {
            Id = dto.Id,
            DOC_CODE = dto.DocCode,
            TV_NAME = dto.Name,
            UpdateDate = dto.UpdateDate
        };
    }

    public static SD_77 MapToSD_77(this NomenklProductTypeFullDto dto)
    {
        return new SD_77
        {
            Id = dto.Id,
            DOC_CODE = dto.DocCode,
            TV_NAME = dto.Name,
            UpdateDate = dto.UpdateDate,
            TV_SHPZ_DC = dto.ShpzDC,
            TV_TYPE = dto.Type
        };
    }
}
