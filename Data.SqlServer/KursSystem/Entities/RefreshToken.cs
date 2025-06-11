using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class RefreshToken
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string TokenHash { get; set; } = null!;

    public string TokenSalt { get; set; } = null!;

    public DateTime TS { get; set; }

    public DateTime ExpiryDate { get; set; }

    public virtual User? User { get; set; }
}
