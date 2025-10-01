namespace DTO.KursReferences.Nomenkl;

public record NomenklTypeDto
{
    public required decimal DocCode { set; get; }
    public required string Name { set; get; }
    public required DateTime? UpdateDate { set; get; }
    public required bool IsDeleted { set; get; }
}
