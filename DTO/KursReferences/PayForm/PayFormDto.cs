namespace DTO.KursReferences.PayForm;

public record PayFormDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required DateTime? UpdateDate { get; set; }
}
