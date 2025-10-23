using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.PayForm;

public static class PayFormMappingExtensions
{
    public static PayFormDto MapToPayFormDto(this SD_189 entity)
    {
        return new PayFormDto
        {
            Id = entity.Id,
            DocCode = entity.DOC_CODE,
            Name = entity.OOT_NAME,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_189 MapToSD_189(this PayFormDto dto)
    {
        return new SD_189
        {
            Id = dto.Id,
            DOC_CODE = dto.DocCode,
            OOT_NAME = dto.Name,
            UpdateDate = dto.UpdateDate
        };
    }

}
