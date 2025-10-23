namespace DTO.KursReferences.KontragentGroup;

public record KontragentGroupFullDto : KontragentGroupDto
{
  
    public bool IsDeleted { get; set; }

}
