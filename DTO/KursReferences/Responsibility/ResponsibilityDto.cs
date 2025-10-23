namespace DTO.KursReferences.Responsibility;

public record ResponsibilityDto
{
    public required Guid Id { set; get; }
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required string NameFull { set; get; }
    public required decimal? ParentDC { set; get; }
    public required bool? IsDeleted { set; get; }
    public required DateTime? UpdateDate { get; set; }
}
