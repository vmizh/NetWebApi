namespace DTO.KursReferences.Unit;

public record UnitDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { get; set; }
    public required string Name { get; set; }
    public required string? OKEI { get; set; }
    public DateTime? UpdateDate { get; set; }
}
