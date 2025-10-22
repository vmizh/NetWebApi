using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.PayForm;

public record PayFormDto
{
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required DateTime? UpdateDate { get; set; }
}

public static class PayFormMappingExtensions
{
    public static PayFormDto MapToPayFormDto(this SD_189 entity)
    {
        return new PayFormDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.OOT_NAME,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_189 MapToSD_189(this PayFormDto dto)
    {
        return new SD_189
        {
            DOC_CODE = dto.DocCode,
            OOT_NAME = dto.Name,
            UpdateDate = dto.UpdateDate
        };
    }

}
