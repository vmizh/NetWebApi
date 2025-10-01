namespace DTO.KursReferences.DeliveryCondition;

public class DeliveryConditionDto
{
    public required decimal DocCode { get; set; }

    public required string Name { get; set; }

    public DateTime? UpdateDate { get; set; }
}
