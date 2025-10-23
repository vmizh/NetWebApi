namespace DTO.KursReferences.NomenklProductType;

public record NomenklProductTypeDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { get; set; }

    public required string Name { get; set; } = null!;

    public DateTime? UpdateDate { get; set; }
}
