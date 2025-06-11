using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Note { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsTester { get; set; }

    public bool IsDeleted { get; set; }

    public byte[]? Avatar { get; set; }

    public string? FullName { get; set; }

    public string? ThemeName { get; set; }

    public string? Password { get; set; }

    public string? PasswordSalt { get; set; }

    public virtual ICollection<Error> Errors { get; set; } = new List<Error>();

    public virtual ICollection<FormLayout> FormLayouts { get; set; } = new List<FormLayout>();

    public virtual ICollection<KontragentCash> KontragentCashes { get; set; } = new List<KontragentCash>();

    public virtual ICollection<LastDocument> LastDocuments { get; set; } = new List<LastDocument>();

    public virtual ICollection<LastMenuUserSearch> LastMenuUserSearches { get; set; } = new List<LastMenuUserSearch>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<UserMenuFavorite> UserMenuFavorites { get; set; } = new List<UserMenuFavorite>();

    public virtual ICollection<UserRightsResponsibilityCenter> UserRightsResponsibilityCenters { get; set; } = new List<UserRightsResponsibilityCenter>();

    public virtual ICollection<DataSource> DBs { get; set; } = new List<DataSource>();

    public virtual ICollection<SignatureType> Signs { get; set; } = new List<SignatureType>();
}
