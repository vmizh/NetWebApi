using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.DeliveryCondition;

public static class DeliveryConditionMappingExtensions
{
    public static DeliveryConditionDto MapToKontragentGroupDto(this SD_103 entity)
    {
        return new DeliveryConditionDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.BUP_NAME,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_103 MatToSD_103(DeliveryConditionDto dto)
    {
        return new SD_103
        {
            DOC_CODE = dto.DocCode,
            UpdateDate = dto.UpdateDate,
            BUP_NAME = dto.Name
        };
    }
}
