using Data.SqlServer.KursReferences.Entities;
using DTO.KursReferences.Region;

namespace DTO.KursReferences.Warehouse;

public static class WarehouseMappingExtensions
{
    public static WarehouseDto MapToWarehouseDto(this SD_27 entity)
    {
        return new WarehouseDto
        {
            DocCode = entity.DOC_CODE,
            Id = entity.Id,
            Name = entity.SKL_NAME,
            KladovshikTabelNumber = entity.TABELNUMBER,
            Region = entity.SKL_REGION_DCNavigation.MapToRegionDto(),
            IsDeleted = entity.IsDeleted,
            IsNegativeRest = entity.SKL_NEGATIVE_REST == 1,
            ParentId = entity.ParentId,
            IsOutBalans = entity.IsOutBalans,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_27 MapToSD_27(this WarehouseDto dto)
    {
        return new SD_27
        {
            DOC_CODE = dto.DocCode,
            SKL_NAME = dto.Name,
            TABELNUMBER = dto.KladovshikTabelNumber,
            SKL_REGION_DC = dto.RegionDC,
            SKL_NEGATIVE_REST = (short?)(dto.IsNegativeRest == true ? 1 : 0),
            Id = dto.Id,
            IsDeleted = dto.IsDeleted,
            ParentId = dto.ParentId,
            IsOutBalans = dto.IsOutBalans,
            UpdateDate = dto.UpdateDate,
        };
    }
}
