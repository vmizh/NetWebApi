using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Region;

public static class RegionMappingExtensions
{
    public static RegionDto MapToRegionDto(this SD_23 entity)
    {
        return new RegionDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.REG_NAME,
            ParentDC = entity.REG_PARENT_DC,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_23 MapToSD_23(this RegionDto dto)
    {
        return new SD_23
        {
            DOC_CODE = dto.DocCode,
            REG_NAME = dto.Name,
            REG_PARENT_DC = dto.ParentDC,
            UpdateDate = dto.UpdateDate
        };
    }
}
