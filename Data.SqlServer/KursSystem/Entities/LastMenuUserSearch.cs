using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class LastMenuUserSearch
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid DbId { get; set; }

    public int MenuId { get; set; }

    public DateTime LastOpen { get; set; }

    public int OpenCount { get; set; }

    public virtual DataSource Db { get; set; } = null!;

    public virtual KursMenuItem Menu { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
