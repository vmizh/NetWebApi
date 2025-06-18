using Common.Helper.Interfaces;
using Common.Helper.Interfaces.Identity;

namespace DTO.KursSystemDTO.KursMenu;

public record KursMenuItemDto : IIntIdentity, IName
{

    /// <summary>
    /// Ключ
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Ссылка на группу документов
    /// </summary>
    public required int GroupId { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; set; } = null!;

    /// <summary>
    /// Картинка
    /// </summary>
    public byte[]? Picture { get; set; }

    /// <summary>
    /// Примечание
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Порядок отрисовки на экране
    /// </summary>
    public int? OrderBy { get; set; }

    /// <summary>
    /// Код имени для обектана стороне клиента
    /// </summary>
    public string? Code { get; set; }

    public bool IsSign { get; set; }
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (int)value;
    }
}
