using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.SDR;

public record SDRSchetDto
{
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required bool IsDeleted { set; get; }
    public required string? Shifr { set; get; }
    public decimal? StateDC => State?.DocCode;
    public required SDRStateDto? State { set; get; }
    public required DateTime? UpdateDate { get; set; }
}

public static class SDRSchetMappingExtensions
{
    public static SDRSchetDto MapToSDRSchetDto(this SD_303 entity)
    {
        return new SDRSchetDto
        {
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
            DOC_CODE = dto.DocCode,
            SHPZ_NAME = dto.Name,
            SHPZ_DELETED = (short)(dto.IsDeleted ? 1 : 0),
            SHPZ_SHIRF = dto.Shifr,
            SHPZ_STATIA_DC = dto.StateDC,
            UpdateDate = dto.UpdateDate
        };
    }
}
