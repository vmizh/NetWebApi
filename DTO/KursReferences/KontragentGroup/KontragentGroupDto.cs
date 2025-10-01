namespace DTO.KursReferences.KontragentGroup;

public class KontragentGroupDto
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public int? ParentId { get; set; }

    public DateTime? UpdateDate { get; set; }
}
