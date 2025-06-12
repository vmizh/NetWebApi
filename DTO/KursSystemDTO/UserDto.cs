using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;

namespace DTO.KursSystemDTO;

public record UserDto : IGuidIdentity, IName
{
    public required string Name { get; set; }

    public string? Note { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsTester { get; set; }

    public bool IsDeleted { get; set; }

    public byte[]? Avatar { get; set; }

    public string? FullName { get; set; }

    public string? ThemeName { get; set; }


    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }

    public required Guid Id { get; set; }
}
// {"Id":"","Name":"","Nate":"","IsAdmin":false,IsTester:false,IsDeleted,Avatar:null,FullName:"",ThemeName:"MetropolisLight"}
