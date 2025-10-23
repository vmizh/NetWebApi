namespace DTO.KursReferences.KontragentGroup;

public record KontragentGroupDto
{
    public required Guid GuidId { set; get; }

    public required int Id { get; set; }

    public required string Name { get; set; }

    public int? ParentId { get; set; }

    public DateTime? UpdateDate { get; set; }
}
