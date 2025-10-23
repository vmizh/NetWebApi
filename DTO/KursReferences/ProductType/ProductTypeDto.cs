namespace DTO.KursReferences.ProductType;

public record ProductTypeDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required string? NameFull { set; get; }
    public required decimal? ParentDC { set; get; }
    public required DateTime? UpdateDate { set; get; }
}
