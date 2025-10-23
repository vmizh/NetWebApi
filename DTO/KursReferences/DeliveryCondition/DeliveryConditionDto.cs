namespace DTO.KursReferences.DeliveryCondition;

public record DeliveryConditionDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { get; set; }

    public required string Name { get; set; }

    public DateTime? UpdateDate { get; set; }
}
