using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

/// <summary>
/// Права пользователей на ЦО
/// </summary>
public partial class UserRightsResponsibilityCenter
{
    public Guid Id { get; set; }

    public Guid DbId { get; set; }

    public Guid UserId { get; set; }

    public decimal RespCentDC { get; set; }

    public virtual DataSource Db { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
