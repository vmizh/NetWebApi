using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.SDR;

public static class SDRStateMappingExtensions
{
    public static SDRStateDto MapToSDRStateDto(this SD_99 entity)
    {
        return new SDRStateDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.SZ_NAME,
            ParentDC = entity.SZ_PARENT_DC,
            IsDohod = entity.SZ_1DOHOD_0_RASHOD == 1,
            UpdateDate = entity.UpdateDate,
            Shifr = entity.SZ_SHIFR
        };
    }

    public static SD_99 MapToSD_99(this SDRStateDto dto)
    {
        return new SD_99
        {
            DOC_CODE = dto.DocCode,
            SZ_NAME = dto.Name,
            SZ_SHIFR = dto.Shifr,
            SZ_PARENT_DC = dto.ParentDC,
            SZ_1DOHOD_0_RASHOD = (short?)(dto.IsDohod ? 1 : 0),
            UpdateDate = dto.UpdateDate,
        };
    }
}
