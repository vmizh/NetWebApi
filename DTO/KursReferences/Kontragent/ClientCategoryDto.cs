namespace DTO.KursReferences.Kontragent;

public record ClientCategoryDto
{
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required DateTime? UpdateDate { get; set; }
}
