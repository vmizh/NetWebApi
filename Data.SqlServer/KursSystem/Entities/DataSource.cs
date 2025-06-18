using Common.Helper.Interfaces.Identity;

namespace Data.SqlServer.KursSystem.Entities;

public partial class DataSource : IGuidIdentity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? ShowName { get; set; }

    public int? Order { get; set; }

    public string? Server { get; set; }

    public string? DBName { get; set; }

    public string? Color { get; set; }

    public bool? IsVisible { get; set; }

    public int? RedisDBId { get; set; }

    public virtual ICollection<Error> Errors { get; set; } = new List<Error>();

    public virtual ICollection<KontragentCash> KontragentCashes { get; set; } = new List<KontragentCash>();

    public virtual ICollection<LastDocument> LastDocuments { get; set; } = new List<LastDocument>();

    public virtual ICollection<LastMenuUserSearch> LastMenuUserSearches { get; set; } = new List<LastMenuUserSearch>();

    public virtual ICollection<SignatureScheme> SignatureSchemes { get; set; } = new List<SignatureScheme>();

    public virtual ICollection<SignatureType> SignatureTypes { get; set; } = new List<SignatureType>();

    public virtual ICollection<UserMenuFavorite> UserMenuFavorites { get; set; } = new List<UserMenuFavorite>();

    public virtual ICollection<UserMenuRight> UserMenuRights { get; set; } = new List<UserMenuRight>();

    public virtual ICollection<UserRightsResponsibilityCenter> UserRightsResponsibilityCenters { get; set; } = new List<UserRightsResponsibilityCenter>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    object IBaseIdentity.Id
    {
        get => Id;
        set => Id = (Guid)value;
    }
}
