using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Unit;

public static class UnitMappingExtensions
{
    public static UnitDto MapToUnitDto(this SD_175 entity)
    {
        return new UnitDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.ED_IZM_NAME,
            OKEI = entity.ED_IZM_OKEI,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_175 MapToSD_175(this UnitDto dto)
    {
        return new SD_175
        {
            DOC_CODE = dto.DocCode,
            ED_IZM_NAME = dto.Name,
            ED_IZM_OKEI = dto.OKEI,
            UpdateDate = dto.UpdateDate
        };
    }
}
