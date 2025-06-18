using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;

namespace DTO.KursSystemDTO.KursMenu;

public record KursMenuGroupDto : IIntIdentity, IName
{
    /// <summary>
    /// Ключ
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Наименование группы
    /// </summary>
    public required string Name { get; set; } = null!;

    /// <summary>
    /// пРИМЕЧАНИЯ
    /// </summary>
    public string? Note { get; set; }

    public int OrderBy { get; set; } = 0;

    public byte[]? Picture { get; set; }

    public int? ParentId { get; set; }

    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (int)value;
    }
}

public record KursMenuGroupWithChildsDto : KursMenuGroupDto
{
    public List<KursMenuGroupDto> Childs { set; get; } = [];
}
