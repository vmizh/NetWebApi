namespace DTO.KursReferences.Region;

public record RegionDto
{
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required decimal? ParentDC { set; get; } = null;
    public required DateTime? UpdateDate { get; set; }

}
