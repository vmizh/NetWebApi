using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;
using DTO.KursSystemDTO.KursMenu;

namespace DTO.KursSystemDTO.User;

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

public record UserWithMenuDto : UserDto
{
    public List<KursMenuItemDto> FavoritesMenu { set; get; } = [];
    public List<KursMenuItemDto> RightsMenu { set; get; } = [];
    public List<UserMenuGroupIerarhyDto> OrderMenu { set; get; } = [];
}

public record UserMenuGroupIerarhyDto
{
    public required KursMenuGroupDto Group { set; get; }
    public required Dictionary<int, KursMenuItemDto> Menus { set; get; } = [];
}
