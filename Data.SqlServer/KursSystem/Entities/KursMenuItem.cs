
using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursSystem.Entities;

/// <summary>
/// Список документов для главного окна приложения
/// </summary>
public partial class KursMenuItem : IIntIdentity
{
    /// <summary>
    /// Ключ
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Ссылка на группу документов
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

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

    public virtual ICollection<FormLayout> FormLayouts { get; set; } = new List<FormLayout>();

    public virtual KursMenuGroup Group { get; set; } = null!;

    public virtual ICollection<LastMenuUserSearch> LastMenuUserSearches { get; set; } = new List<LastMenuUserSearch>();

    public virtual ICollection<SignatureScheme> SignatureSchemes { get; set; } = new List<SignatureScheme>();

    public virtual ICollection<UserMenuFavorite> UserMenuFavorites { get; set; } = new List<UserMenuFavorite>();

    public virtual ICollection<UserMenuRight> UserMenuRights { get; set; } = new List<UserMenuRight>();

    public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (int)value;
    }
}
