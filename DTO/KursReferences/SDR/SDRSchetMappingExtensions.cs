using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.SDR;

public static class SDRSchetMappingExtensions
{
    public static SDRSchetDto MapToSDRSchetDto(this SD_303 entity)
    {
        return new SDRSchetDto
        {
            Id = entity.Id,
            DocCode = entity.DOC_CODE,
            Name = entity.SHPZ_NAME,
            IsDeleted = entity.SHPZ_DELETED == 1,
            Shifr = entity.SHPZ_SHIRF,
            State = entity.SHPZ_STATIA_DCNavigation?.MapToSDRStateDto(),
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_303 MapToSD_303(this SDRSchetDto dto)
    {
        return new SD_303
        {
            Id = dto.Id,
            DOC_CODE = dto.DocCode,
            SHPZ_NAME = dto.Name,
            SHPZ_DELETED = (short)(dto.IsDeleted ? 1 : 0),
            SHPZ_SHIRF = dto.Shifr,
            SHPZ_STATIA_DC = dto.StateDC,
            UpdateDate = dto.UpdateDate
        };
    }
}
